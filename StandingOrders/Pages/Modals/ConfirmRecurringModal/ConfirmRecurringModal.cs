using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;

namespace StandingOrders.Pages
{
    public class ConfirmRecurringModal : BasePage<ConfirmRecurringModalMap, ConfirmRecurringModalAsserter>
    {
        public ConfirmRecurringModal() : base(@"")
        {

        }

        public void Confirm()
        {
            Map.ConfirmBtn.Click();
            Driver.WaitForLoad(120);
        }

        public void Close()
        {
            Map.CancelBtn.Click();
            Driver.Browser.WaitForElementInvisibility(By.Id(Map.Id), 30);
            Driver.WaitForLoad();
        }
    }
}
