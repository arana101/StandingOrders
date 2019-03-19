using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class ScheduleNewTripPage : BasePage<ScheduleNewTripPageMap, ScheduleNewTripPageAsserter>
    {
        public ScheduleNewTripPage() : base(@"")
        {

        }

        private static Random gen = new Random();
        private const int DROPDOWN_WAIT = 10;
        private IWebElement date;
        private bool isValidDay = false;
        private const string EX_MESSAGE = "Unable to find proper date after 10 tries";
        private const string BROWSER_IE = "internet explorer";
        private const string BROWSER_CHROME = "chrome";
        private ScheduleNewTripPageData data = new ScheduleNewTripPageData();
        private string aptDate;
        private Helper.BrowserTypes browser;

        public void FillStep1(dataSchedulerCaller data, int relationship = 1, int reason = 1)
        {
            Map.CallerName.Clear();
            Map.CallerName.SendKeys(data.FirstName);

            Map.CallerLastName.Clear();
            Map.CallerLastName.SendKeys(data.LastName);

            var relationshipDrp = new SelectElement(Map.RelationshipDrp);
            relationshipDrp.SelectByValue(relationship.ToString()); //Select "Member(Self)"

            Map.CallerPhone.Clear();
            Map.CallerPhone.Click();
            Map.CallerPhone.SendKeys(data.ContactNo);

            var reasonDrp = new SelectElement(Map.CallReasonDrp);
            reasonDrp.SelectByValue(reason.ToString()); //Select "Schedule a Trip"
        }

        public void FillStep2(string id)
        {
            Map.MemberId.Clear();
            Map.MemberId.SendKeys(id);

            Driver.ScrollToElement(Map.NextBtn);

            //Custom click is used because Safari couldn't click on button
            Driver.CustomClick(Map.SearchBtn);

            Driver.WaitForLoad(data.DefaultWait);

            Driver.Browser.FindElement(By.TagName("tr"), 30);

            //Click on first rearch result
            Driver.CustomClick(Map.TableRows[0]);

            Driver.WaitForLoad(data.DefaultWait);
        }

        public void FillStep3()
        {
            var languageDrp = new SelectElement(Map.PrimaryLanguage);
            languageDrp.SelectByText(data.language[2].ToString()); //Select "language" English
            Map.NextBtn.Click();
            Driver.WaitForLoad(data.DefaultWait);
        }

        public void FillStep5()
        {

        }

        public void FillStep6()
        {
            Driver.CustomClick(Map.NextBtn);

            Driver.WaitForLoad();
        }

        public void OpenManageTripsStep7()
        {
            Map.Step7ManageTrips.Click();

            Driver.WaitForLoad();
        }
        /// <summary>
        /// Get the random date for appointment. Returns formatted string "MMMM dd, dddd yyyy - hh:mm tt"
        /// </summary>
        /// <returns>string</returns>
        public string GetAppointmentDate()
        {
            DateTime start = DateTime.Today;
            DateTime end = new DateTime(2020, 1, 1, 9, 0, 0);
            int range = (end - start).Days;
            DateTime date = start.AddDays(gen.Next(range)).AddHours(9);
            string formattedDate = date.ToString(data.AptDateFormat2);

            return formattedDate;
        }

        /// <summary>
        /// Check if day is valid for scheduling. Returns true if valid, false if invalid (scheduled or restricted)
        /// </summary>
        /// <param name="element"></param>
        /// <returns>bool</returns>
        public bool ValidateAppointmentDate(IWebElement element)
        {
            string attr = element.GetAttribute("class");

            if (attr.Contains("restrticted"))
            {
                return false;
            }
            else if (attr.Contains("scheduled"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method for choosing valid date (not scheduled and restrictred) in Appointment datetimepicker
        /// </summary>
        /// <returns></returns>
        public IWebElement SetValidAppointmentDate(string inputdate = "")
        {
            string appdate;

            if (String.IsNullOrEmpty(inputdate))
            {
                appdate = GetAppointmentDate();
            }
            else
            {
                appdate = String.Format("{0} 09:00 am", inputdate);
            }

            int count = 0;
            Actions actions = new Actions(Driver.Browser);

            string browserName = Driver.GetBrowserCapabilities().GetCapability("browserName").ToString();

            while (!isValidDay)
            {
                if (browserName == BROWSER_IE || browserName == BROWSER_CHROME)
                {
                    Map.ApptDateTime.Click();
                    actions.MoveToElement(Map.ApptDateTime, -10, 0).Click().Build().Perform();
                    Map.ApptDateTime.Click();
                    Map.ApptDateTime.SendKeys(appdate);
                }
                else
                {
                    Map.ApptDateTime.Clear();
                    System.Threading.Thread.Sleep(5000);
                    Map.ApptDateTime.SendKeys(appdate);
                }

                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(data.DefaultWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(data.DatetimepickerDaysClassName)));

                //Find the element on DatePicker
                date = Driver.Browser.FindElement(By.ClassName(data.DatetimepickerDaysClassName)).FindElement(By.ClassName("active"));
                isValidDay = ValidateAppointmentDate(date);

                if (!isValidDay)
                {
                    if (browserName == BROWSER_IE || browserName == BROWSER_CHROME)
                    {
                        Map.ApptDateTime.Clear();

                        actions.MoveToElement(Map.ApptDateTime, -10, 0).Click().Build().Perform();
                        System.Threading.Thread.Sleep(5000);
                    }
                    else
                    {
                        actions.MoveToElement(Map.ApptDateTime, -10, 0).Click().Build().Perform();
                        System.Threading.Thread.Sleep(5000);
                        Map.ApptDateTime.Click();
                    }

                    count++;
                }

                if (count == 10)
                {
                    throw new WebDriverException(EX_MESSAGE);
                }
            }

            return date;
        }

        public bool CheckStateOfCheckbox(IWebElement element)
        {
            Driver.ScrollToElement(element);
            
            return (element.Selected) ? true : false;
        }

        public string CreateRecurringTrip(dataSchedulerAppointmentInfo appointmentInfo)
        {
            Driver.ScrollToElement(Map.Step4CallHistoryAccordion);

            aptDate = Helper.GetValueAttribute(Map.ApptDateTime);

            if (!CheckStateOfCheckbox(Map.Recurring))
            {
                Driver.CustomClick(Map.Recurring);
                Driver.WaitForLoad(data.DefaultWait);
            }            

            var RecurringTrip = Map.TripContainer.FindElement(By.PartialLinkText("Recurring Trip"));
            Driver.CustomClick(RecurringTrip);

            Driver.ScrollToElement(Map.NextBtn);

            var recurringItems = new RecurringTripMap();
            var recurring = new RecurringTrip();

            recurring.SelectFrequency(appointmentInfo);

            recurring.SelectDates(appointmentInfo);

            Driver.CustomClick(recurringItems.ConfirmButton);

            Driver.WaitForLoad(data.DefaultWait);

            ConfirmRecurring();

            Driver.CustomClick(Map.NextBtn);

            Driver.WaitForLoad(data.DefaultWait);

            return aptDate;
        }

        public void SearchForTrip(string appointmentDate, int stepNumber = 7)
        {
            string browserName = Driver.GetBrowserCapabilities().GetCapability("browserName").ToString();

            if (stepNumber != 7 && stepNumber != 3)
            {
                Driver.ScrollToElement(Map.ManageTrips);
                Driver.CustomClick(Map.ManageTrips);

                Driver.WaitForModalWindowIsDisplayedById("ManageTripOpenModalContainer");
                Driver.CustomClick(Map.ManageTripsModalButtons[2]);
                Driver.WaitForLoad();

                System.Threading.Thread.Sleep(2000);
            }

            Map.ManageTripsDate.Clear();
            Driver.WaitForLoad(data.DefaultWait);
            Map.ManageTripsDate.SendKeys(Helper.ConvertCustomDateToUS(appointmentDate, data.AptDateFormat2));

            if (browserName == "safari")
            {
                Actions actions = new Actions(Driver.Browser);
                actions.MoveToElement(Map.ApptDateTime, -3, 0).Click().Build().Perform();
            }
            else
            {
                Map.ManageTripsDate.SendKeys(Keys.Enter);
            }

            Driver.WaitForLoad(data.DefaultWait);

            var pagNext = Driver.Browser.FindElement(By.Id("trips_tbl_paginate")).FindElement(By.ClassName("next"));

            if (!pagNext.GetAttribute("class").ToString().Contains("disabled"))
            {
                var nextBtn = pagNext.FindElement(By.TagName("a"));

                do
                {
                    Driver.CustomClick(nextBtn);
                    Driver.WaitForLoad();
                } while (!pagNext.GetAttribute("class").ToString().Contains("disabled"));
            }

            IList<IWebElement> trips = Map.TripsTableBody.FindElements(By.TagName("tr"));
            Driver.CustomClick(trips[trips.Count - 1]);
            Driver.WaitForLoad(Helper.IMPLICIT_WAIT_TIMEOUT);
        }

        public void Step4FillGeneralInfo(string trippurpose, string benefitplan)
        {
            Map.Step4TripPurpCont.Click();
            var tripPurp = Driver.Browser.FindElement(By.CssSelector(".select2-search--dropdown>input"), 30);

            if (Map.Step4PurposeText.Text == "")
            {
                tripPurp.Clear();
                tripPurp.SendKeys(trippurpose);
                IWebElement purpose = Driver.Browser.FindElement(By.XPath(@"id('select2-tripPurposeSelect-results')/li[1]/ul[1]/li[1]"), 30);
                purpose.Click();
                Driver.WaitForLoad(DROPDOWN_WAIT);
            }

            var benefit = new SelectElement(Map.BenefitPlan);
            if (!benefit.SelectedOption.Text.Contains(benefitplan))
            {
                benefit.SelectByIndex(1);
                Driver.WaitForLoad();
            }
        }

        private void ConfirmRecurring()
        {
            try
            {
                var recModal = new ConfirmRecurringModal();
                recModal.Confirm();
            }
            catch
            {

            }
        }
    }
}
