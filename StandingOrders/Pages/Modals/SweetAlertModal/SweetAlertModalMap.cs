using StandingOrders.Base;
using OpenQA.Selenium;

namespace StandingOrders.Pages
{
    public class SweetAlertModalMap : BasePageElementMap
    {
        public string ModalSelector => ".sweet-alert.showSweetAlert.visible";

        public IWebElement Modal => Driver.Browser.FindElement(By.CssSelector(ModalSelector));
        public IWebElement Yes => Modal.FindElement(By.ClassName("confirm"));
        public IWebElement No => Modal.FindElement(By.ClassName("cancel"));
    }
}
