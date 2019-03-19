using StandingOrders.Base;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class DashboardPageMap : BasePageElementMap
    {
        public IWebElement Logo => Browser.FindElement(By.XPath("//a[@id='index']/img"));

        public IWebElement LogoText => Browser.FindElement(By.XPath("//a[@id='index']/label"));

        public IWebElement ButtonsBar => Browser.FindElement(By.ClassName("topbar-actions"));

        public IList<IWebElement> Buttons => ButtonsBar.FindElements(By.ClassName("md-skip"));

        public IWebElement Menu => Browser.FindElement(By.Id(Helper.MENU), 30);

        public IList<IWebElement> MenuItems => Menu.FindElements(By.ClassName("dropdown-fw"));

        public IList<IWebElement> MenuItemsLinks => Menu.FindElements(By.ClassName("text-uppercase"));

    }
}
