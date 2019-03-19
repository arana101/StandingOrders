using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StandingOrders.Base;

namespace StandingOrders.Pages
{
    public class PrivacyPolicyModal : BasePage<PrivacyPolicyModalMap, PrivacyPolicyModalAsserter>
    {
        public PrivacyPolicyModal() : base(@"")
        {

        }

        public void AcceptPolicy()
        {
            Driver.ScrollToElement(Map.AcceptBtn);

            var acceptLabel = Helper.GetParentElement(Map.AcceptCheckbox).FindElement(By.TagName("label"));
            acceptLabel.Click();
            Map.AcceptBtn.Click();
            Driver.WaitForModalWindowInvisibilityById(Map.Modal.GetAttribute("id"));
        }
    }
}
