using StandingOrders.Base;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class RoundTripMap : ScheduleNewTripPageMap
    {
        public IWebElement RT => Step4.FindElement(By.Id("api_round_tab_id"));
        public IWebElement Step4Mot => RT.FindElement(By.Id("api_mots"));
        public IWebElement Step4Street => RT.FindElement(By.Id("origin_input_id_0"));
        public IWebElement RoundTripPickupLeg1 => RT.FindElement(By.Id("origin_pickuptime"));
        public IWebElement RoundTripPickupLeg2 => RT.FindElement(By.Id("origin_pickuptime_2"));
        public IWebElement Step4City => RT.FindElement(By.Id("origin_city"));
        public IWebElement Step4State => RT.FindElement(By.Id("origin_state"));
        public IWebElement Step4Zip => RT.FindElement(By.Id("origin_zip"));
        public IWebElement Step4County => RT.FindElement(By.Id("origin_county"));
        public IWebElement BestContact => RT.FindElement(By.Id("origin_bestcontact"));
        public IWebElement SearchPreviousAddress => RT.FindElement(By.Id("search_addresses_btn"));
        public IWebElement Validate => RT.FindElement(By.Id("api_validate_button_id_0"));
        public IWebElement IsHomeAddressPick => RT.FindElement(By.Id("round_pickup_iha"));
        public IWebElement IsHomeAddressDest => RT.FindElement(By.Id("round_dest_iha"));
        public IWebElement DestinationName => RT.FindElement(By.Id("exicting_dest_input_id_0"));
        public IWebElement DestinationStreet => RT.FindElement(By.Id("exicting_dest_street"));
        public IWebElement DestinationCity => RT.FindElement(By.Id("destination_city"));
        public IWebElement DestinationState => RT.FindElement(By.Id("destination_state"));
        public IWebElement DestinationZip => RT.FindElement(By.Id("destination_zip"));
        public IWebElement DestinationCounty => RT.FindElement(By.Id("destination_county"));
        public IWebElement DoctorNameDest => RT.FindElement(By.Id("facility_name_destination_0"));
        public IWebElement FacilityPhoneDest => RT.FindElement(By.Id("facility_phone_destination_0"));
        public IWebElement DrFirstNameDest => RT.FindElement(By.Id("doctor_firstname_destination_0"));
        public IWebElement DrLastNameDest => RT.FindElement(By.Id("doctor_lastname_destination_0"));
        public IWebElement DrFirstNamePick => RT.FindElement(By.Id("doctor_firstname_pickup_0"));
        public IWebElement DrLastNamePick => RT.FindElement(By.Id("doctor_lastname_pickup_0"));
        public IWebElement DoctorNamePick => RT.FindElement(By.Id("facility_name_pickup_0"));
        public IWebElement FacilityPhonePick => RT.FindElement(By.Id("facility_phone_pickup_0"));
        public IWebElement WillCall => RT.FindElement(By.Id("will_call"));
        public IWebElement DestdAdressRadioButtonsGroup => RT.FindElement(By.ClassName(@"nmn-network-providers-search-radios-container"));
        public IList<IWebElement> RadioButtonsInputs => DestdAdressRadioButtonsGroup.FindElements(By.TagName("input"));
        public IList<IWebElement> RadioButtonsLabels => DestdAdressRadioButtonsGroup.FindElements(By.ClassName("mt-radio"));
    }
}