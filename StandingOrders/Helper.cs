using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace StandingOrders
{
    public class Helper
    {
        public const int PAGE_LOAD_TIMEOUT = 120;
        public const int IMPLICIT_WAIT_TIMEOUT = 120;
        public const string STAGING_URL = "https://staging.natmedtrans.com/QANMNSchedulerNewUI/";
        public const string BROWSERSTACK_URL = "http://hub-cloud.browserstack.com/wd/hub/";
        public const string LOCAL_SELENIUM_GRID_URL = "http://172.31.54.248:4444/wd/hub";
        private static readonly CultureInfo provider = CultureInfo.InvariantCulture;
        public static string SCREEN_SHOT_PATH = Driver.CreateScreenshotsDirectory();

        #region Capabilities constants
        public const string SCREEN_RESOLUTION = "1920x1080";
        public const string BROWSERSTACK_USER = "andrewlomakin1";
        public const string BROWSERSTACK_KEY = "t7Gx4bGv53CNtVXR3zpR";
        #endregion

        #region other constants
        public const string MENU = "PortalMenuDiv";
        public const string PARENT_ELEMENT = "./parent::*";
        public const string MENU_ITEM = "dropdown-menu-fw";
        public const string SUB_MENU_ITEMS = ".//li//a";
        public const string ACTIVITY_MANAGER_MENU = "menu_item_activity_manager_id";
        public const string ADMIN_MENU = "menu_item_admin_id";
        public const string MEMBERS_MENU = "menu_item_members_id";
        public const string PAYER_MENU = "menu_item_payers_id";
        public const string PROVIDERS_MENU = "menu_item_providers_id";
        public const string REPORTS_MENU = "menu_item_reports_id";
        public const string TOAST_MESSAGE = "toast-container";
        #endregion

        public enum BrowserTypes
        {
            Firefox,
            InternetExplorer,
            Chrome,
            Safari,
            Edge
        }

        public enum AppointmentSearchMode
        {
            ByAppointmentId = 1,
            ByPeriod = 2,
            ByMemberName = 3         
        }

        /// <summary>
        /// Custom exception for the incorrect link.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns>string with custom assertion exception</returns>
        public static string CustomException(string current, string actual, string expected)
        {
            string customException = String.Format("Incorrect link for {0}. Actual link is {1}, Expected: {2}", 
                                                    current, actual, expected);

            return customException;
        }

        /// <summary>
        /// Checking visibility of the given element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="url"></param>
        /// <param name="isVisible"></param>
        public static void CheckItem(IWebElement element, string url, bool isVisible)
        {
            Assert.IsTrue(element.GetAttribute("href").Contains(url), 
                            CustomException(element.Text, element.GetAttribute("href").ToString(), "URL should be ended on: " + url));

            if (isVisible)
            {
                Assert.IsTrue(element.Displayed, String.Format("Element {0} is not displayed", element.Text));
            }
            else
            {
                Assert.IsFalse(element.Displayed, String.Format("Element {0} should not displayed", element.Text));
            }
        }

        /// <summary>
        /// Helper function for Member creation
        /// </summary>
        /// <returns></returns>
        public static string GetSaltFromDate()
        {
            DateTime date = DateTime.Now;
            var salt = date.Ticks.ToString();

            return salt;
        }

        /// <summary>
        /// Gets the parent IWebElement of the given element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IWebElement GetParentElement(IWebElement element)
        {
            IWebElement parent = element.FindElement(By.XPath("../.."));

            return parent;
        }

        /// <summary>
        /// Start browser, maximize it and navigate to Staging URL
        /// </summary>
        /// <param name="browser"></param>
        public static void PrepareBrowser(BrowserTypes browser, string url)
        {
            Driver.StartBrowser(browser);
            Driver.Browser.Manage().Window.Maximize();
            Driver.Navigate(url);
        }

        /// <summary>
        /// Browserstack capability for Firefox browser
        /// </summary>
        /// <param name="capability"></param>
        /// <returns>Firefox Capabilities</returns>
        public static DesiredCapabilities FirefoxCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "Firefox");
            capability.SetCapability("browser_version", "62.0");
            capability.SetCapability("resolution", SCREEN_RESOLUTION);
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("browserstack.console", "verbose");
            capability.SetCapability("browserstack.networkLogs", "true");
            capability.SetCapability("browserstack.video", "true");
            capability.SetCapability("browserstack.selenium_version", "3.14.0");
            capability.SetCapability("browserstack.geckodriver", "0.20.1");
            capability.SetCapability("browserstack.user", BROWSERSTACK_USER);
            capability.SetCapability("browserstack.key", BROWSERSTACK_KEY);

            return capability;
        }

        /// <summary>
        /// Browserstack capability for Internet Explorer browser
        /// </summary>
        /// <param name="capability"></param>
        /// <returns>InternetExplorer Capabilities</returns>
        public static DesiredCapabilities IeCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "IE");
            capability.SetCapability("browser_version", "11.0");
            capability.SetCapability("resolution", SCREEN_RESOLUTION);
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("browserstack.networkLogs", "true");
            capability.SetCapability("browserstack.selenium_version", "3.14.0");
            capability.SetCapability("browserstack.ie.arch", "x32");
            capability.SetCapability("browserstack.ie.driver", "3.8.0");
            capability.SetCapability("browserstack.ie.enablePopups", "true");
            capability.SetCapability("browserstack.user", BROWSERSTACK_USER);
            capability.SetCapability("browserstack.key", BROWSERSTACK_KEY);

            return capability;
        }

        public static DesiredCapabilities IeCapabilitiesLocalGrid()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("javascriptEnabled", true);
            capability.SetCapability("databaseEnabled", true);
            capability.SetCapability("browserConnectionEnabled", true);
            capability.SetCapability("webStorageEnabled", true);
            capability.SetCapability("nativeEvents", true);
            capability.SetCapability("ignoreProtectedModeSettings", true);
            capability.SetCapability("enableElementCacheCleanup", true);
            capability.SetCapability("ie.ensureCleanSession", true);
            
            return capability;
        }

        /// <summary>
        /// Browserstack capability for Chrome browser
        /// </summary>
        /// <param name="capability"></param>
        /// <returns>Chrome Capabilities</returns>
        public static DesiredCapabilities ChromeCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "69.0");
            capability.SetCapability("resolution", SCREEN_RESOLUTION);
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("browserstack.console", "verbose");
            capability.SetCapability("browserstack.networkLogs", "true");
            capability.SetCapability("browserstack.selenium_version", "3.14.0");
            capability.SetCapability("browserstack.chrome.driver", "2.42");
            capability.SetCapability("browserstack.user", BROWSERSTACK_USER);
            capability.SetCapability("browserstack.key", BROWSERSTACK_KEY);

            return capability;
        }

        /// <summary>
        /// Browserstack capability for Safari browser
        /// </summary>
        /// <param name="capability"></param>
        /// <returns>Safari Capabilities</returns>
        public static DesiredCapabilities SafariCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("os", "OS X");
            capability.SetCapability("os_version", "High Sierra");
            capability.SetCapability("browser", "Safari");
            capability.SetCapability("browser_version", "11.1");
            capability.SetCapability("resolution", SCREEN_RESOLUTION);
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("browserstack.selenium_version", "3.14.0");
            capability.SetCapability("browserstack.safari.enablePopups", "true");
            capability.SetCapability("browserstack.safari.allowAllCookies", "true");
            capability.SetCapability("browserstack.user", BROWSERSTACK_USER);
            capability.SetCapability("browserstack.key", BROWSERSTACK_KEY);

            return capability;
        }

        /// <summary>
        /// Browserstack capability for Edge browser
        /// </summary>
        /// <param name="capability"></param>
        /// <returns>Edge Capabilities</returns>
        public static DesiredCapabilities EdgeCapabilities()
        {

            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "Edge");
            capability.SetCapability("browser_version", "17.0");
            capability.SetCapability("resolution", SCREEN_RESOLUTION);
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("browserstack.networkLogs", "true");
            capability.SetCapability("browserstack.selenium_version", "3.14.0");
            capability.SetCapability("browserstack.edge.enablePopups", "true");
            capability.SetCapability("browserstack.user", BROWSERSTACK_USER);
            capability.SetCapability("browserstack.key", BROWSERSTACK_KEY);

            return capability;
        }

        public static string GetValueAttribute(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void OptionListContains(SelectElement select, string[] values, int startIndex = 0)
        {
            IList<IWebElement> options = select.Options;

            for (int i = startIndex; i < options.Count; i++)
            {
                Assert.AreEqual(values[i], options[i].Text);
            }
        }

        public static string ConvertCustomDateToUS(string customDate, string customFormat)
        {
            string convertedDate = DateTime.ParseExact(customDate, customFormat, provider).ToString("MM/dd/yyyy");

            return convertedDate;
        }

        public static string NormalizeWhiteSpace(string input)
        {
            int len = input.Length,
                index = 0,
                i = 0;
            var src = input.ToCharArray();
            bool skip = false;
            char ch;
            for (; i < len; i++)
            {
                ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        if (skip) continue;
                        src[index++] = ch;
                        skip = true;
                        continue;
                    default:
                        skip = false;
                        src[index++] = ch;
                        continue;
                }
            }

            return new string(src, 0, index);
        }

        public static void CleanupBrowser(bool cancelTrips = false)
        {
            try
            {
                Driver.StopBrowser();
            }
            finally
            {
            }
        }

        public static void WaitForCurrentWindowAlert(IWebElement alert, int seconds = 10)
        {
            By alertLocator = By.Id(Helper.TOAST_MESSAGE);
            var alertClick = new Actions(Driver.Browser);
            alertClick.MoveToElement(alert).Click().Build().Perform();
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(alertLocator));            
        }

        public static void SimpleLogin(string login, string password)
        {
            var loginPage = new Pages.LoginPage();

            loginPage.Login(login, password, true);
            Driver.Browser.FindElement(By.Id(MENU), 30);
            loginPage.Validate().VerifyLogin();
        }
    }
}
