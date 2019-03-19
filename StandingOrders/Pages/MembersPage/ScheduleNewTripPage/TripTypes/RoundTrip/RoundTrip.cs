using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;


namespace StandingOrders.Pages
{
    public class RoundTrip : BasePage<RoundTripMap, RoundTripAsserter>
    {
        public RoundTrip() : base(@"")
        {

        }

        private const int DROPDOWN_WAIT = 10;
        private ScheduleNewTripPageData data = new ScheduleNewTripPageData();
        private ScheduleNewTripPage tripPage = new ScheduleNewTripPage();
        private IWebElement date;

        public void FillStep4(dataSchedulerAppointmentInfo appdata, string homeAddress = "pickup")
        {
            date = tripPage.SetValidAppointmentDate(appdata.AppointmentDate);

            try
            {
                date.Click();
            }
            catch (WebDriverException)
            {

            }

            Driver.WaitForLoad(data.DefaultWait);

            tripPage.Step4FillGeneralInfo(appdata.TripPurpose, appdata.BenefitPlan);

            Driver.ScrollToElement(Map.Step4Mot);
            var mot = new SelectElement(Map.Step4Mot);
            mot.SelectByText(appdata.MOT);
            Driver.WaitForLoad(DROPDOWN_WAIT);

            Map.RoundTripPickupLeg2.Clear();
            Map.RoundTripPickupLeg2.SendKeys("10:00 AM");

            if (homeAddress == "pickup")
            {
                Map.RadioButtonsLabels[0].Click();

                ClearDestination();

                if (!tripPage.CheckStateOfCheckbox(Map.IsHomeAddressPick))
                {
                    var isHomeAddrPick = Helper.GetParentElement(Map.IsHomeAddressPick).FindElement(By.ClassName("box"));
                    Driver.CustomClick(isHomeAddrPick);
                }

                FillDestination(appdata.DestinationAddressNetworkProvider[0]);
            }
            else if (homeAddress == "dest")
            {
                ClearPickup();

                FillPickup(appdata.DestinationAddressNetworkProvider[0]);
            }
            else
            {
                throw new ArgumentException(String.Format("Unknown input parameter: {0}", homeAddress));
            }
            
        }

        private void FillDestination(dataSchedulerAppointmentInfoDestinationAddressNetworkProvider destdata)
        {
            Driver.ScrollToElement(Map.NextBtn);
            Map.DestinationName.SendKeys(destdata.DestiantionName);
            Driver.WaitForLoad(data.DefaultWait);

            Map.DestinationStreet.SendKeys(destdata.Street);
            Driver.WaitForLoad(data.DefaultWait);

            Map.DestinationCity.SendKeys(destdata.City);
            Map.DestinationState.SendKeys(destdata.State);
            Map.DestinationZip.SendKeys(destdata.Zip);
            Map.DestinationCounty.SendKeys(destdata.County);
            Map.DoctorNameDest.SendKeys(destdata.DestiantionName);
            Map.FacilityPhoneDest.Click();
            Map.FacilityPhoneDest.SendKeys(destdata.FacilityPhone);
            if(string.IsNullOrEmpty(Helper.GetValueAttribute(Map.DrFirstNameDest))) Map.DrFirstNameDest.SendKeys("Dr.Test");
            if (string.IsNullOrEmpty(Helper.GetValueAttribute(Map.DrLastNameDest))) Map.DrLastNameDest.SendKeys("Dr.Test");
        }

        private void FillPickup(dataSchedulerAppointmentInfoDestinationAddressNetworkProvider destdata)
        {
            Driver.ScrollToElement(Map.DestinationName);
            Map.Step4Street.SendKeys(destdata.Street);
            Map.Step4City.SendKeys(destdata.City);
            Map.Step4State.SendKeys(destdata.State);
            Map.Step4Zip.SendKeys(destdata.Zip);
            Map.Step4County.SendKeys(destdata.County);
            Map.DoctorNamePick.SendKeys(destdata.DestiantionName);
            Map.FacilityPhonePick.Click();
            Map.FacilityPhonePick.SendKeys(destdata.FacilityPhone);
        }

        private void ClearDestination()
        {
            Driver.ScrollToElement(Map.NextBtn);

            Map.DestinationName.Clear();
            Map.DestinationStreet.Clear();
            Map.DestinationCity.Clear();
            Map.DestinationState.Clear();
            Map.DestinationZip.Clear();
            Map.DestinationCounty.Clear();
            Map.DoctorNameDest.Clear();
            Map.FacilityPhoneDest.Clear();
            Map.DrFirstNameDest.Clear();
            Map.DrLastNameDest.Clear();
        }

        private void ClearPickup()
        {
            Driver.ScrollToElement(Map.NextBtn);

            Map.Step4Street.Clear();
            Map.Step4City.Clear();
            Map.Step4State.Clear();
            Map.Step4Zip.Clear();
            Map.Step4County.Clear();
            Map.DoctorNamePick.Clear();
            Map.FacilityPhonePick.Clear();
            Map.DrFirstNamePick.Clear();
            Map.DrLastNamePick.Clear();
        }

        public void ChangeMOT(string motName)
        {
            var mot = new SelectElement(Map.Step4Mot);
            mot.SelectByText(motName);
            Driver.WaitForLoad(DROPDOWN_WAIT);

            Map.Validate.Click();
            Driver.WaitForLoad(data.ValidationTimeout);
        }        
    }
}
