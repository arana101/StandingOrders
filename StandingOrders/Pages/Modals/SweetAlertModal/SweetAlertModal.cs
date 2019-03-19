using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;

namespace StandingOrders.Pages
{
    public class SweetAlertModal : BasePage<SweetAlertModalMap, SweetAlertModalAsserter>
    {
        public SweetAlertModal() : base(@"")
        {

        }

        public void Confirm()
        {
            Map.Yes.Click();

            Driver.Browser.WaitForElementInvisibility(By.CssSelector(Map.ModalSelector), 30);
        }
    }
}
