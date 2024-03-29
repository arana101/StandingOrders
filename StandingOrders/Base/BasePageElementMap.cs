﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StandingOrders.Base
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;
        }

        public void SwitchToDefault()
        {
            Browser.SwitchTo().DefaultContent();
        }
    }
}
