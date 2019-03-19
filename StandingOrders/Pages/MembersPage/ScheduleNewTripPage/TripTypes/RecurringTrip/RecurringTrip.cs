using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;

namespace StandingOrders.Pages
{
    public class RecurringTrip : BasePage<RecurringTripMap, RecurringTripAsserter>
    {
        public RecurringTrip() : base(@"")
        {

        }

        public void SelectFrequency(dataSchedulerAppointmentInfo data)
        {
            var frequency = new SelectElement(Map.Frequency);

            short desiredfrequency = 0;

            Int16.TryParse(data.Frequency[0].ToString(), out desiredfrequency);

            frequency.SelectByValue((desiredfrequency - 1).ToString());
        }

        public void SelectDates(dataSchedulerAppointmentInfo data)
        {
            var selectedDates = Map.Dates.Where(x => x.GetAttribute("class").CaseInsensitiveContains("day-of-week-selected"));

            foreach (var date in selectedDates)
            {
                date.Click();
            }

            if (data.Dates[0].Sunday == "1")
            {
                Map.Dates[0].Click();
            }

            if (data.Dates[0].Monday == "1")
            {
                Map.Dates[1].Click();
            }

            if (data.Dates[0].Tuesday == "1")
            {
                Map.Dates[2].Click();
            }

            if (data.Dates[0].Wednesday == "1")
            {
                Map.Dates[3].Click();
            }

            if (data.Dates[0].Thursday == "1")
            {
                Map.Dates[4].Click();
            }

            if (data.Dates[0].Friday == "1")
            {
                Map.Dates[5].Click();
            }

            if (data.Dates[0].Saturday == "1")
            {
                Map.Dates[6].Click();
            }
        }
    }
}
