using StandingOrders.Base;
using OpenQA.Selenium;

namespace StandingOrders.Pages
{
    public class LoginPageMap : BasePageElementMap
    {
        private LoginPage page = new LoginPage();

        public IWebElement FrancesLogo => Browser.FindElement(By.XPath(page.loginLogoPath));

        public IWebElement InviteText => Browser.FindElement(By.XPath(page.loginInviteTextPath));

        public IWebElement User => Browser.FindElement(By.Id(page.loginUser));

        public IWebElement Password => Browser.FindElement(By.Id(page.loginPassword));

        public IWebElement LoginButton => Browser.FindElement(By.Id(page.loginButton));

        public IWebElement ForgotPasswordLink => Browser.FindElement(By.XPath(page.loginForgotLink));

        public IWebElement ForgotPasswordWindow => Browser.FindElement(By.Id(page.loginForgotWindow));

        public IWebElement ClosePasswordWindow => Browser.FindElement(By.Id(page.loginCloseForgot));

        public IWebElement UserEmail => ForgotPasswordWindow.FindElement(By.Id(page.userEmailId));

        public IWebElement SendPasswordBtn => ForgotPasswordWindow.FindElement(By.Id(page.forgotPasswordBtnId));

        public IWebElement ChangePasswordWindow => Browser.FindElement(By.Id(page.changePasswordWindowId));

        public IWebElement NewPassword => ChangePasswordWindow.FindElement(By.Id(page.newPasswordId));

        public IWebElement ConfirmPassword => ChangePasswordWindow.FindElement(By.Id(page.confirmPasswordId));

        public IWebElement ChangePasswordBtn => ChangePasswordWindow.FindElement(By.Id(page.changePasswordBtnId));
    }
}
