using StandingOrders.Base;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class RecurringTripMap : ScheduleNewTripPageMap
    {
        public IWebElement RC => Step4.FindElement(By.Id("api_recurring_content_id"));
        public IWebElement DatePane => RC.FindElement(By.ClassName("days-of-week"));
        public IList<IWebElement> Dates => DatePane.FindElements(By.ClassName("day-of-week"));
        public IWebElement StartDate => RC.FindElement(By.Id("StartDate"));
        public IWebElement EndDate => RC.FindElement(By.Id("EndDate"));
        public IWebElement ConfirmButton => RC.FindElement(By.Id("confirm-recurring-trip"));
        public IWebElement Frequency => RC.FindElement(By.XPath(".//*[contains(@data-bind, 'RecurringTrip.Frequency')]"));
    }
}
