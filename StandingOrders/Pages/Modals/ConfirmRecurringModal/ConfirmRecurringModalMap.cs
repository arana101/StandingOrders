using StandingOrders.Base;
using OpenQA.Selenium;

namespace StandingOrders.Pages
{
    public class ConfirmRecurringModalMap : BasePageElementMap
    {
        public string Id => "api_recurring_content_id";

        public IWebElement Modal => Driver.Browser.FindElement(By.Id(Id), 5);
        public IWebElement ConfirmBtn => Modal.FindElement(By.Id("rec_trip_confirm"), 5);
        public IWebElement CancelBtn => Modal.FindElement(By.Id("rec_trip_close"), 5);
    }
}
