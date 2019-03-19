using StandingOrders.Base;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace StandingOrders.Pages
{
    public class ScheduleNewTripPageMap : BasePageElementMap
    {
        public string SIWindowID => "si-modal";
        public string INWindowID => "in-modal";
        public string RecapWindowID => "recapModal";
        public string CallerNameErrorID => "callerName-error";
        public string CallerLastNameErrorID => "lastName-error";
        public string CallerRelationshipErrorID => "relship-error";
        public string CallerPhoneErrorID => "callerPhone-error";
        public string CallerReasonErrorID => "callReason-error";
        public string SecsItemId => "secs";
        public string EmailDrpId => "ui-id-1";
        public string EmailDrpItemClassName => "ui-menu-item-wrapper";
        public string CallReasonItemXPath => "//*[contains(., 'Call Reason')]";

        public IWebElement BackBtn => Browser.FindElement(By.Id("wizard_previous_btn_id"));
        public IWebElement NextBtn => Browser.FindElement(By.Id("wizard_next_btn_id"));
        public IWebElement RecapBtn => Browser.FindElement(By.Id("trip_recap"));
        public IWebElement SubmitBtn => Browser.FindElement(By.Id("formFinish")); 
        public IWebElement RecapWindow => Browser.FindElement(By.Id(RecapWindowID));
        public IWebElement SpecialInstructionsWindow => Browser.FindElement(By.Id(SIWindowID));
        public IWebElement CloseSIWindowBtn => SpecialInstructionsWindow.FindElement(By.ClassName("fa-close"));
        public IWebElement SpecialInstruction => SpecialInstructionsWindow.FindElement(By.ClassName("mt-comment-date"));
        public IWebElement InternalNotesWindow => Browser.FindElement(By.Id(INWindowID));
        public IWebElement CloseINWindowBtn => InternalNotesWindow.FindElement(By.ClassName("fa-close"));
        public IWebElement InternalNote => InternalNotesWindow.FindElement(By.ClassName("mt-comment-date"));
        public IWebElement InternalNotePhone => InternalNotesWindow.FindElement(By.Id("SiPhone"));
        public IWebElement InternalNotePrevNotes => InternalNotesWindow.FindElement(By.Id("Text_41_39_0"));

        public IWebElement FormWizard => Browser.FindElement(By.Id("formWizard"));
        public IWebElement NavPillsBar => FormWizard.FindElement(By.ClassName("nav-pills"));
        public IList<IWebElement> NavPills => NavPillsBar.FindElements(By.TagName("li"));
        public IWebElement ManageTrips => Browser.FindElement(By.PartialLinkText("Manage Trips"));
        public IWebElement ManageTripsModal => Browser.FindElement(By.Id("ManageTripOpenModalContainer"));
        public IList<IWebElement> ManageTripsModalButtons => ManageTripsModal.FindElements(By.TagName("button"));
        public IWebElement ScheduleTrips => Browser.FindElement(By.PartialLinkText("Schedule Trips"));

        #region Step1
        public IWebElement Step1 => Browser.FindElement(By.Id("CallerInfo"));
        public IWebElement CallerName => Step1.FindElement(By.Id("callerName"));
        public IWebElement CallerLastName => Step1.FindElement(By.Id("lastName"));
        public IWebElement RelationshipDrp => Step1.FindElement(By.Id("relship"));
        public IWebElement CallerPhone => Step1.FindElement(By.Id("callerPhone"));
        public IWebElement CallReasonDrp => Step1.FindElement(By.Id("callReason"));
        public IWebElement CallerEmail => Step1.FindElement(By.Id("callerEmail"));
        #endregion

        #region Step2
        public IWebElement Step2 => Browser.FindElement(By.Id("MemberLookup"));
        public IWebElement MemberId => Step2.FindElement(By.Id("ml_mem_id"));
        public IWebElement MemberFirstName => Step2.FindElement(By.Id("ml_mem_fName"));
        public IWebElement MemberLastName => Step2.FindElement(By.Id("ml_mem_lName"));
        public IWebElement MemberDOB => Step2.FindElement(By.Id("ml_mem_bDay"));
        public IWebElement SearchBtn => Step2.FindElement(By.Id("ml_search_btn_id"));
        public IWebElement MemberLookupTable => Step2.FindElement(By.Id("mem_Results"));
        public IWebElement MemberLookupTableBody => MemberLookupTable.FindElement(By.TagName("tbody"));
        public IList<IWebElement> TableRows => MemberLookupTableBody.FindElements(By.TagName("tr"));
        public IWebElement PreviousMemberLookupTable => Step2.FindElement(By.Id("previous_Members"));
        public IWebElement PreviousMemberLookupTableBody => PreviousMemberLookupTable.FindElement(By.TagName("tbody"));
        public IList<IWebElement> PreviousTableRows => PreviousMemberLookupTableBody.FindElements(By.TagName("tr"));
        public IWebElement MostRecentTripsTable => Step2.FindElement(By.ClassName("mem-lup-trips"));
        public IList<IWebElement> MostRecentTripsTableRows => MostRecentTripsTable.FindElements(By.TagName("tr"));
        #endregion

        #region Step3
        public IWebElement Step3 => Browser.FindElement(By.Id("VerifyMemberInfo"));
        public IWebElement FName => Step3.FindElement(By.Id("s3_mem_first_name"));
        public IWebElement LName => Step3.FindElement(By.Id("s3_mem_last_name"));
        public IWebElement PrimaryDiagnosis => Step3.FindElement(By.Id("select2-s3_mem_primary_diagnosis-container"));
        public IWebElement PrimaryCare => Step3.FindElement(By.Id("s3_mem_primary_care_physician"));
        public IWebElement PrimaryLanguage => Step3.FindElement(By.Id("s3_mem_primary_language"));
        public IWebElement Gender => Step3.FindElement(By.Id("s3_mem_gender"));
        public IWebElement Age => Step3.FindElement(By.Id("s3_mem_age"));
        public IWebElement Ambulatory => Step3.FindElement(By.Id("s3_mem_ambulatory"));
        public IWebElement NonGroupRide => Step3.FindElement(By.Id("s3_mem_non_group_ride"));
        public IWebElement SecondaryLanguage => Step3.FindElement(By.Id("s3_mem_secondary_language"));
        public IWebElement ResidentStreetAddr => Step3.FindElement(By.Id("s3_mem_address_1"));
        public IWebElement AddressType => Step3.FindElement(By.Id("s3_mem_address_type"));
        public IWebElement AssistDevice => Step3.FindElement(By.Id("s3_mem_assistive_devices"));
        public IWebElement SecondStreetAddress => Step3.FindElement(By.Id("s3_mem_address_alt"));
        public IWebElement Email => Step3.FindElement(By.Id("s3_mem_email_address"));
        public IWebElement Mot => Step3.FindElement(By.Id("s3_mem_transportation_mode"));
        public IWebElement City => Step3.FindElement(By.Id("s3_mem_city"));
        public IWebElement State => Step3.FindElement(By.Id("s3_mem_state"));
        public IWebElement Zip => Step3.FindElement(By.Id("s3_mem_zip"));
        public IWebElement County => Step3.FindElement(By.Id("s3_mem_county"));
        public IWebElement MemberPreferences => Step3.FindElement(By.Id("s3_mem_member_preferences"));
        public IWebElement Phone => Step3.FindElement(By.Id("s3_mem_cell_phone"));
        public IWebElement SecondPhone => Step3.FindElement(By.Id("s3_mem_secondary_phone"));
        public IWebElement Notification => Step3.FindElement(By.Id("s3_mem_notification_preferences"));
        public IWebElement SpecialInsructionsBtn => Step3.FindElement(By.Id("nmn_special_instructions_btn"));
        public IWebElement InternalNotesBtn => Step3.FindElement(By.Id("nmn_internal_notes_btn"));
        public IWebElement Step3MemberInfoPanel => Step3.FindElement(By.Id("member_info_panel"));
        public IWebElement Step3ExpandMemberInfoPanelLink => Step3MemberInfoPanel.FindElement(By.TagName("a"));
        public IWebElement Step3MemberInformationAccordion => Step3.FindElement(By.Id("accordion_section_01_TripScheduler"));
        public IList<IWebElement> Step3memberInformation => Step3MemberInformationAccordion.FindElements(By.TagName("span"));
        public IWebElement Step3CallHistoryPanel => Step3.FindElement(By.Id("call_history_panel"));
        public IWebElement Step3ExpandCallHistoryPanelLink => Step3CallHistoryPanel.FindElement(By.TagName("a"));
        public IWebElement Step3CallHistoryAccordion => Step3.FindElement(By.Id("accordion_section_02_TripScheduler"));
        public IList<IWebElement> Step3CallHistory => Step3CallHistoryAccordion.FindElements(By.TagName("span"));
        public IWebElement Step3EntranceLocationTable => Step3.FindElement(By.Id("s3_mem_entrance_location"));
        public IList<IWebElement> Step3EntranceLocationItems => Step3EntranceLocationTable.FindElements(By.ClassName("nmn-windrose"));
        #endregion

        #region Step4
        public IWebElement Step4 => Browser.FindElement(By.Id("AppointmentInfo"));
        public IWebElement ApptDateTime => Step4.FindElement(By.Id("api_datetime_id"));
        public IWebElement Step4TripPurpCont => Step4.FindElement(By.CssSelector(".col-md-6>.form-group>.select2>.selection>.select2-selection.select2-selection--single"));
        public IWebElement Step4PurposeText => Step4.FindElement(By.Id("select2-tripPurposeSelect-container"));
        public IWebElement Step4AssistDevices => Step4.FindElement(By.Id("api_assistive_devices"));
        public IWebElement Step4AdditionalPassengers => Step4.FindElement(By.Id("api_additional_pass"));
        public IWebElement BenefitPlan => Step4.FindElement(By.Id("api_benefit_options"));
        public IWebElement Recurring => Step4.FindElement(By.Id("api_recurring_toggle_id"));
        public IWebElement RoundTrip => Step4.FindElement(By.Id("api_round_trip_id"));
        public IWebElement SingleLeg => Step4.FindElement(By.Id("api_single_trip_id"));
        public IWebElement MultiLeg => Step4.FindElement(By.Id("api_multi_trip_id"));
        public IWebElement Step4MemberInfoPanel => Step4.FindElement(By.Id("member_info_panel"));
        public IWebElement Step4ExpandMemberInfoPanelLink => Step4MemberInfoPanel.FindElement(By.TagName("a"));
        public IWebElement Step4MemberInformationAccordion => Step4.FindElement(By.Id("accordion_section_01_TripScheduler"));
        public IList<IWebElement> Step4memberInformation => Step4MemberInformationAccordion.FindElements(By.TagName("span"));
        public IWebElement Step4CallHistoryPanel => Step4.FindElement(By.Id("call_history_panel"));
        public IWebElement Step4ExpandCallHistoryPanelLink => Step4CallHistoryPanel.FindElement(By.TagName("a"));
        public IWebElement Step4CallHistoryAccordion => Step4.FindElement(By.Id("accordion_section_02_TripScheduler"));
        public IList<IWebElement> Step4CallHistory => Step4CallHistoryAccordion.FindElements(By.TagName("span"));
        public IWebElement Step4TripInfoPanel => Step4.FindElement(By.Id("trip_info_panel"));
        public IWebElement Step4ExpandTripInfoPanelLink => Step4TripInfoPanel.FindElement(By.TagName("a"));
        public IWebElement Step4TripInfoAccordion => Step4.FindElement(By.Id("accordion_section_03_TripScheduler"));
        public IWebElement TripContainer => Step4.FindElement(By.Id("api_trip_container_id"));
        #endregion

        #region Step5
        public IWebElement Step5 => Browser.FindElement(By.Id("ProviderSelection"));
        public IWebElement SelectPreferredProvider => Step5.FindElement(By.Id("set_provider"));        
        public IWebElement Legs => Step5.FindElement(By.Id("leg"));
        public IWebElement ProviderName => Step5.FindElement(By.Id("provider_name"));
        public IWebElement ClearBtn => Step5.FindElement(By.Id("clear"));
        public IWebElement SearchProviderBtn => Step5.FindElement(By.Id("search_provider"));
        public IWebElement ProviderTab => Step5.FindElement(By.Id("provider_tab"));
        public IList<IWebElement> ProviderTabItems => Step5.FindElements(By.TagName("a"));
        public IWebElement SmartDispatchTabContent => Step5.FindElement(By.Id("smart_dispatch_"));
        public IWebElement SmartDispatchResults => SmartDispatchTabContent.FindElement(By.TagName("tbody"));
        public IWebElement PreviousProvidersTabContent => Step5.FindElement(By.Id("previous_providers_"));
        public IWebElement PreviousProviderResults => PreviousProviderResults.FindElement(By.TagName("tbody"));
        public IWebElement SearchResultsTabContent => Step5.FindElement(By.Id("search_results_"));
        public IWebElement SearchResults => SearchResultsTabContent.FindElement(By.TagName("tbody"));
        public IWebElement Step5MemberInfoPanel => Step5.FindElement(By.Id("member_info_panel"));
        public IWebElement Step5ExpandMemberInfoPanelLink => Step5MemberInfoPanel.FindElement(By.TagName("a"));
        public IWebElement Step5MemberInformationAccordion => Step5.FindElement(By.Id("accordion_section_01_TripScheduler"));
        public IList<IWebElement> Step5memberInformation => Step5MemberInformationAccordion.FindElements(By.TagName("span"));
        public IWebElement Step5CallHistoryPanel => Step5.FindElement(By.Id("call_history_panel"));
        public IWebElement Step5ExpandCallHistoryPanelLink => Step5CallHistoryPanel.FindElement(By.TagName("a"));
        public IWebElement Step5CallHistoryAccordion => Step5.FindElement(By.Id("accordion_section_02_TripScheduler"));
        public IList<IWebElement> Step5CallHistory => Step5CallHistoryAccordion.FindElements(By.TagName("span"));
        public IWebElement Step5TripInfoPanel => Step5.FindElement(By.Id("trip_info_panel"));
        public IWebElement Step5ExpandTripInfoPanelLink => Step5TripInfoPanel.FindElement(By.TagName("a"));
        public IWebElement Step5TripInfoAccordion => Step5.FindElement(By.Id("accordion_section_03_TripScheduler"));
        #endregion

        #region Step6
        public IWebElement Step6 => Browser.FindElement(By.Id("TripSummary"));
        public IWebElement Step6TripPurpose => Step6.FindElement(By.Id("apt_trip_purpose"));
        public IWebElement Step6ApptDate => Step6.FindElement(By.Id("apt_appt_date"));
        public IWebElement CloseRecapBtn => RecapWindow.FindElement(By.ClassName("btn-default"));
        public IList<IWebElement> SummaryItems => RecapWindow.FindElements(By.TagName("b"));
        #endregion

        #region Step7
        public IWebElement Step7 => Browser.FindElement(By.Id("WrapUp"));
        public IWebElement ConfirmationText => Step7.FindElement(By.XPath("//div/div[2]/div/div[2]/div[1]/div/h1/font/b"));
        public IWebElement Step7ManageTrips => Step7.FindElements(By.ClassName("btn-lg")).Where(x => x.Text.CaseInsensitiveContains("Manage Trips")).First();
        #endregion

        #region Manage Trips
        public IWebElement ManageTripsTab => Browser.FindElement(By.Id("manage_trips"));
        public IWebElement FilterBy => ManageTripsTab.FindElement(By.Id("filter_by"));
        public IWebElement ManageTripsDate => ManageTripsTab.FindElement(By.Id("appointment_date"));
        public IWebElement TripsTable => ManageTripsTab.FindElement(By.Id("trips_tbl"));
        public IWebElement TripsTableBody => ManageTripsTab.FindElement(By.TagName("tbody"));
        #endregion
    }
}
