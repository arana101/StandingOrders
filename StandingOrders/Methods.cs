using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using StandingOrders.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingOrders
{
    class Methods
    {
        private Helper.BrowserTypes browser;
        public string aptDate;

        public Methods(Helper.BrowserTypes browser)
        {
            this.browser = browser;
        }

        public void Initialize(string url, dataSchedulerLoginInfo data)
        {
            Helper.PrepareBrowser(browser, url);

            Helper.SimpleLogin(data.Login, data.Password);

            DashboardPage dashboard = new DashboardPage();
            dashboard.OpenMembersTab();
        }

        public void FillStep1(dataSchedulerCaller data)
        {
            var items = new ScheduleNewTripPageMap();
            var page = new ScheduleNewTripPage();
            page.FillStep1(data);

            items.NextBtn.Click();
            Driver.WaitForLoad(300);
        }

        public void FillStep2(string memberId)
        {
            var items = new ScheduleNewTripPageMap();
            var page = new ScheduleNewTripPage();
            page.FillStep2(memberId);

            items.NextBtn.Click();
            Driver.WaitForLoad(300);
        }

        public void FillStep3()
        {
            var items = new ScheduleNewTripPageMap();
            var page = new ScheduleNewTripPage();
            page.FillStep3();
        }

        public void FillStep4(dataSchedulerAppointmentInfo appdata)
        {
            var items = new ScheduleNewTripPageMap();
            var page = new ScheduleNewTripPage();
            var data = new ScheduleNewTripPageData();

            var roundTrip = new RoundTrip();
            var roundTripItems = new RoundTripMap();

            Driver.ScrollToElement(items.NextBtn);
            
            Driver.ScrollToElement(items.ApptDateTime);
            items.ApptDateTime.Clear();
            Driver.WaitForLoad(data.DefaultWait);
            roundTrip.FillStep4(appdata);
            try
            { 
                Driver.CustomClick(roundTripItems.Validate);
            }
            catch (Exception ex)
            {
                Driver.SaveScreenshot(Helper.SCREEN_SHOT_PATH);
                Console.WriteLine($"{DateTime.Now}  -  Validate the trip on AppointmentInfo page. " +
                    $"Exception message {ex.Message}. \n Please, see the screenshot with error");
            }
            Driver.WaitForLoad(data.ValidationTimeout);
        }

        public void FillStep5(dataSchedulerProvider schedulerProvider)
        {
            var items = new ScheduleNewTripPageMap();

            IList<IWebElement> providers = items.SmartDispatchTabContent.FindElements(By.TagName("tr"));
            var prov = providers.Where(p => p.Text.Contains(schedulerProvider.ProviderName)).First();
            Driver.CustomClick(prov);

            items.NextBtn.Click();
            Driver.WaitForLoad(300);
        }

        public void FillStep6()
        {
            var items = new ScheduleNewTripPageMap();

            items.SubmitBtn.Click();
            Driver.WaitForLoad(300);
        }

        public void OpenManageTripsStep7()
        {
            var page = new ScheduleNewTripPage();
            page.OpenManageTripsStep7();
        }

        public void ValidateRecurringTrip(string recurDate, string memberId)
        {
            var page = new ScheduleNewTripPage();
            var data = new ScheduleNewTripPageData();
            string text = "";

            page.SearchForTrip(recurDate);

            try
            {
                text = page.Validate().ValidateRecurringTrip();
            }
            catch
            {
                Console.WriteLine("Incorrect Recurring Trip was created!");
            }

            Console.WriteLine(String.Format("Recurring Appointment Date: {0} - Member ID: {1}", recurDate, memberId));
            Console.WriteLine(text);
            Console.WriteLine("----------------------------");

            var filepath = Directory.GetCurrentDirectory();

            using (StreamWriter sw = File.AppendText(Path.Combine(filepath, "Appointments.txt")))
            {
                sw.WriteLine(String.Format("Recurring Appointment Date: {0} - Member ID: {1}", recurDate, memberId));
                sw.WriteLine(text);
                sw.WriteLine("----------------------------");
            }
        }

        public void RoundTripRecurring(dataSchedulerAppointmentInfo dataScheduler)
        {
            var items = new ScheduleNewTripPageMap();
            var page = new ScheduleNewTripPage();
            var data = new ScheduleNewTripPageData();

            aptDate = page.CreateRecurringTrip(dataScheduler);
        }
    }
}
