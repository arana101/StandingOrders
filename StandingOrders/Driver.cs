using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Collections.Generic;

namespace StandingOrders
{
    public class Driver
    {
        private static WebDriverWait _browserWait;

        private static readonly ThreadLocal<IWebDriver> _driver;

        static Driver()
        {
            _driver = new ThreadLocal<IWebDriver>();
        }

        public static IWebDriver Browser
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _driver.Value;
            }

            set
            {
                _driver.Value = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        /// <summary>
        /// Creating Browser instance with defined type (Safari, Edge, etc.). Session is created in its own thread.
        /// </summary>
        /// <param name="browserType"></param>
        /// <param name="defaultTimeOut"></param>
        public static void StartBrowser(Helper.BrowserTypes browserType, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
                case Helper.BrowserTypes.Firefox:
                    //Browser = new RemoteWebDriver(new Uri(Helper.BROWSERSTACK_URL), Helper.FirefoxCapabilities());

                    break;

                case Helper.BrowserTypes.InternetExplorer:
                    //Browser = new RemoteWebDriver(new Uri(Helper.BROWSERSTACK_URL), Helper.IeCapabilities());

                    break;

                case Helper.BrowserTypes.Chrome:
                    var chromeOptions = new ChromeOptions
                    {
                        //BinaryLocation = @"D:\Chrome\GoogleChromePortable\App\Chrome-bin\chrome.exe"
                    };

                    //chromeOptions.AddArguments("headless");
                    //chromeOptions.AddArguments("--window-size=1920,1080");
                    //chromeOptions.AddArguments("--no-sandbox");
                    chromeOptions.AddArguments(new List<string>() {
                                                                "--silent-launch",
                                                                "--window-size=1920,1080",
                                                                "no-sandbox",
                                                                "headless",});
                    Browser = new ChromeDriver(chromeOptions);

                    break;

                case Helper.BrowserTypes.Safari:
                    //Browser = new RemoteWebDriver(new Uri(Helper.BROWSERSTACK_URL), Helper.SafariCapabilities());

                    break;

                case Helper.BrowserTypes.Edge:
                    //Browser = new RemoteWebDriver(new Uri(Helper.BROWSERSTACK_URL), Helper.EdgeCapabilities());

                    break;

                default:
                    break;
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser.Dispose();
            if (Browser != null)
                Browser = null;
        }

        /// <summary>
        /// Warapper over the standard Selenium Navigate function 
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            Browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Waoit for the AJAX call to be completed in acceptable time
        /// </summary>
        /// <param name="maxSeconds"></param>
        public static void WaitForAjaxComplete(int maxSeconds = 30)
        {
            var isAjaxCallComplete = false;
            for (var i = 1; i <= maxSeconds; i++)
            {
                isAjaxCallComplete = (bool)((IJavaScriptExecutor)Browser).
                ExecuteScript("return window.jQuery != undefined && jQuery.active == 0");

                if (isAjaxCallComplete)
                {
                    return;
                }
                Thread.Sleep(1000);
            }

            throw new WebDriverTimeoutException(string.Format("Timed out after {0} seconds", maxSeconds));
        }

        /// <summary>
        /// Wrapper over standard Assertion exception
        /// </summary>
        /// <param name="element"></param>
        public static void IsDisplayed(IWebElement element)
        {
            Assert.IsTrue(element.Displayed, element.Text + "is not displayed");
        }

         /// <summary>
         /// Wait for circle loader to be disappeared
         /// </summary>
         /// <param name="seconds"></param>
        public static void WaitForLoad(int seconds = 30)
        {
            string browserName = GetBrowserCapabilities().GetCapability("browserName").ToString();

            WebDriverWait wait = null;

            try
            {
                if (seconds >= 60)
                {
                    int timeout = seconds / 60;
                    wait = new WebDriverWait(Browser, TimeSpan.FromMinutes(timeout));
                }

                wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(seconds));

                if (browserName == "safari" || browserName == "internet explorer")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("circle-big")));
                }
                else
                {
                    IWebElement circleLoad = Browser.FindElement(By.ClassName("blockOverlay"), 10);

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(circleLoad));
                }

                Thread.Sleep(2000);
            }
            catch (WebDriverTimeoutException)
            {

            }
        }

        /// <summary>
        /// Wrapper over standard Selenium PageLoad Timeout
        /// </summary>
        /// <param name="seconds"></param>
        public static void WaitForPageLoad(int seconds = 10)
        {
            Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Waiting for the element to be attached to the DOM
        /// </summary>
        /// <param name="seconds"></param>
        public static IWebElement WaitForElementExistsByClassName(string className, int seconds = 30)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Browser)
                
                {
                    Timeout = TimeSpan.FromSeconds(seconds),
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                //Ignoring of WebDriverExcetion is needed, because sometimes safari throws "Unknown server-side error"
                fluentWait.IgnoreExceptionTypes(typeof(WebDriverException));
                IWebElement element = fluentWait.Until(x => x.FindElement(By.ClassName(className)));

                return element;
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException(string.Format("Element with ClassName {0} was not loaded during {1} seconds", className, seconds));
            }
        }

        /// <summary>
        /// Wait for the element to be attached to the DOM and to be clickable. Finds element by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seconds"></param>
        public static void WaitForElementClickableByID(string id, int seconds = 30)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Browser)
            {
                Timeout = TimeSpan.FromSeconds(seconds),
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement element = fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id)));
        }

        /// <summary>
        /// Get currently running browser capabilities (browser name, version, platform, etc.)
        /// </summary>
        /// <returns></returns>
        public static ICapabilities GetBrowserCapabilities()
        {
            ICapabilities capabilities = ((RemoteWebDriver)Browser).Capabilities;
            return capabilities;
        }

        /// <summary>
        /// Scrolling to the element using JavaScript (for Firefox, IE, etc. Chrome performs scrolling automatically)
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        /// <summary>
        /// Function for clicking element using JavaScript (if standard element.Click() wouldn't work)
        /// </summary>
        /// <param name="element"></param>
        public static void CustomClick(IWebElement element)
        {
            ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Function for waiting Modal Window to be appeared
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        public static void WaitForModalWindowIsDisplayedById(string id, int timeout = 30)
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        /// <summary>
        /// Function for waiting disappearing Modal Windows using Ids of Modal Windows.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        public static void WaitForModalWindowInvisibilityById(string id, int timeout = 30)
        {
            Thread.Sleep(1000);

            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id(id)));
        }

        public static void CustomDropdownSelect(IWebElement element, int index)
        {
            ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].selectedIndex=" + index + ";", element);
        }

        public static string CreateScreenshotsDirectory()
        {
            string path = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), DateTime.Now.ToString("MM_dd_yyyy__hh_mm"));

            DirectoryInfo di = Directory.CreateDirectory(path);

            return path;
        }

        public static void SaveScreenshot(string path)
        {
            var filename = String.Format("{0}\\{1}.jpg", path, DateTime.Now.ToString("MM_dd_yyyy__hh_mm"));

            Screenshot image = ((ITakesScreenshot)Browser).GetScreenshot();

            if (!File.Exists(filename))
            {
                image.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
