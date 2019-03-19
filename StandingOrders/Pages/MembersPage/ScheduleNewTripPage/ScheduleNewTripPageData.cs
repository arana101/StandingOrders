using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingOrders.Pages
{
    public class ScheduleNewTripPageData
    {
        public string AptDateFormat => "MMMM dd, dddd yyyy - hh:mm tt";
        public string AptDateFormat2 => "MM/dd/yyyy hh:mm tt";
        public string Step7Message => "Your trip has been scheduled successfully";
        public string DatetimepickerDaysClassName => "datetimepicker-days";
        public int DefaultWait => 120;
        public int ValidationTimeout => 600;
        public string TestEmail => "test@gmail.com";

        public string[] relationship =
        {
            "",
            "Member(Self)",
            "Child",
            "Parent",
            "Spouse",
            "Other Relative",
            "Caregiver",
            "Home Health Aide",
            "Care Management",
            "Facility",
            "Healthcare Provider",
            "Plan Representative"
        };

        public string[] reason =
        {
            "",
            "Schedule a Trip",
            "Cancel a Trip",
            "Return Trip",
            "Edit an Existing Trip",
            "Confirm a Trip",
            "Feedback"
        };

        public readonly string[] language =
        {
            " ",
            "N/A",
            "English",
            "Spanish",
            "Russian",
            "Mandarin",
            "Cantonese",
            "Creole",
            "Korean",
            "Vietnamese"
        };

        public readonly string[] mot =
        {
            " ",
            "2 Man Ambulette",
            "ALS",
            "Ambulette",
            "Bariatric Wheelchair",
            "BLS",
            "Livery",
            "Livery D2D",
            "Mass Transit",
            "Mileage Reimbursement",
            "SCT",
            "Stretcher/Gurney",
            "Airfare",
            "Helicopter"
        };

        public readonly string[] assistDevices =
        {
            "Standard Size Wheelchair",
            "Motorized Wheelchair",
            "Cane",
            "Walker",
            "Stretcher",
            "Oxygen (Self Administered)",
            "Oxygen (Administered by medical professional)",
            "Bariatric equipment",
            "Luggage or other personal belongings",
            "Car Seats"
        };

        public readonly string[] addressType =
{
            " ",
            "N/A",
            "Primary Address",
            "Business Address",
            "Billing Address",
            "Payment Address",
            "Secondary Address"
        };

        public readonly string[] notifications = { "Phone call" };
    }
}
