using StandingOrders.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace StandingOrders.Pages
{
    public class LoginPage : BasePage<LoginPageMap,LoginPageAsserter>
    {
        public LoginPage() : base(@"")
        {

        }
        //private static ConnectionStringSettings sqlConnectionSettings = ConfigurationManager.ConnectionStrings["StagingSQLServer"];
        //public string EncryptionKey => ConfigurationManager.AppSettings["EncryptKey"];

        public string loginLogoPath => "/html/body/div[1]/div/center/img";
        public string loginInviteTextPath => "/html/body/div[1]/div/p";
        public string loginUser => "user";
        public string loginPassword => "password";
        public string loginButton => "btnLogin";
        public string loginForgotLink => "//*[@id='form1']/div[5]/a";
        public string loginForgotWindow => "forgetPasswordModel";
        public string loginCloseForgot => "btncloseemail";
        public string userEmailId => "userEmail";
        public string forgotPasswordBtnId => "btnForgotPassword";
        public string changePasswordWindowId => "divChangePassword";
        public string newPasswordId => "txtNewPassword";
        public string confirmPasswordId => "txtConfirmPassword";
        public string changePasswordBtnId => "btnChangePassword";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        public DashboardPageMap Login(string user, string password, bool valid)
        {
            Map.User.Clear();
            Map.User.SendKeys(user);
            Map.Password.Clear();
            Map.Password.SendKeys(password);
            Map.LoginButton.Click();

            CheckPolicy();            

            return (valid) ? new DashboardPageMap() : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        public void WaitForLoginAlert(IWebElement alert ,int seconds = 10)
        {
            By alertLocator = By.Id(Helper.TOAST_MESSAGE);
            Actions alertClick = new Actions(Driver.Browser);
            alertClick.MoveToElement(alert).Click().Build().Perform();
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(alertLocator));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        public void WaitForForgotPasswordWindows(int seconds)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[5]")));
        }

        private void CheckPolicy()
        {
            try
            {
                Driver.WaitForModalWindowIsDisplayedById("divPrivacyPolicyModal", 10);
                var privacyPolicy = new PrivacyPolicyModal();
                privacyPolicy.AcceptPolicy();
            }
            catch
            {

            }
        }
    }
}
