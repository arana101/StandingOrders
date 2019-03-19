using StandingOrders.Base;
using OpenQA.Selenium;

namespace StandingOrders.Pages
{
    public class PrivacyPolicyModalMap : BasePageElementMap
    {
        public IWebElement Modal => Driver.Browser.FindElement(By.Id("divPrivacyPolicyModal"), 30);
        public IWebElement AcceptCheckbox => Modal.FindElement(By.Id("chbxAcceptPolicy"));
        public IWebElement AcceptBtn => Modal.FindElement(By.Id("btnAcceptPolicy"));
    }
}
