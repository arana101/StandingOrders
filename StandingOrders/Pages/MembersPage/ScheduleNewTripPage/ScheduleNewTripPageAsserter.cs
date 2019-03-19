using System;
using StandingOrders.Base;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Globalization;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace StandingOrders.Pages
{
    public class ScheduleNewTripPageAsserter : BasePageAsserter<ScheduleNewTripPageMap>
    {
        private const int APR_DATE_TIME_INDEX = 1;
        private const string LABEL_TAG = "label";
        private const string COLOR_ATTRIBUTE = "color";
        private const string BOTTOM_COLOR_ATTRIBUTE = "border-bottom-color";
        private const string COLOR = "231, 61, 74";
        private const int WAIT_FOR_SECS_TIMEOUT = 2000;
        private const int WAIT_FOR_MINS_TIMEOUT = 60000;
        private readonly string[] notifications = { "Phone call" };
        private readonly string[] memberPrefs = { "" };
        private readonly string[] assistDev = { "" };
        private const string BROWSER_IE = "internet explorer";


        private readonly CultureInfo provider = CultureInfo.InvariantCulture;

        private ScheduleNewTripPage page = new ScheduleNewTripPage();
        private ScheduleNewTripPageData data = new ScheduleNewTripPageData();

        private void ValidateMultipleSelectItemsText(IList<IWebElement> elements, string[] desiredValues)
        {
            if (elements.Count > 0)
            {
                int index = 0;
                foreach (var element in elements)
                {
                    Assert.IsTrue(element.Text.Contains(desiredValues[index]),
                        String.Format("Dropdown option is incorrect. Expected {0}. Actual {1}", desiredValues[index], element.Text));
                    index++;
                }
            }
        }

        public string ValidateRecurringTrip()
        {
            string recurringText = Map.TripsTableBody.FindElement(By.ClassName("mt-comment")).Text;

            Assert.IsTrue(recurringText.CaseInsensitiveContains("Recurring trip"));

            return recurringText;
        }
    }
}
