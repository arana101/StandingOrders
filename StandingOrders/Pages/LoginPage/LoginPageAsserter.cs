using StandingOrders.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace StandingOrders.Pages
{
    public class LoginPageAsserter : BasePageAsserter<LoginPageMap>
    {
        public void IsDisplayed(IWebElement element)
        {
            Assert.IsTrue(element.Displayed, String.Format("Element {0} is not displayed", element.Text));
        }

        public void ForgotPasswordWindowDisplayed()
        {
            Map.ForgotPasswordLink.Click();
            Driver.WaitForModalWindowIsDisplayedById("forgetPasswordModel");
            IsDisplayed(Map.ForgotPasswordWindow);
            Map.ClosePasswordWindow.Click();
            Driver.WaitForModalWindowInvisibilityById("forgetPasswordModel");
        }

        public void VerifyLogin()
        {
            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("Dashboard.aspx"), "Incorrect URL. URL should be ended on Dashboard.aspx");
        }

        public void VerifyProviderLogin()
        {
            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("/dashboard/dashboard"), "Incorrect URL. URL should be ended on /dashboard/dashboard");

        }

        public void VerifyLogout()
        {
            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("QANMNSchedulerNewUI"), "Incorrect URL. URL should be ended on QANMNSchedulerNewUI");
        }
    }
}
