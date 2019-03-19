using StandingOrders.Base;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class MembersPageMap : BasePageElementMap
    {
        public IWebElement Menu => Browser.FindElement(By.Id(Helper.MENU));

        public IWebElement MembersLink => Menu.FindElement(By.Id(Helper.MEMBERS_MENU));

        public IWebElement Members => MembersLink.FindElement(By.XPath(Helper.PARENT_ELEMENT));

        public IWebElement MembersMenu => Members.FindElement(By.ClassName(Helper.MENU_ITEM));

        public IList<IWebElement> MembersMenuItems => MembersMenu.FindElements(By.XPath(Helper.SUB_MENU_ITEMS));
    }
}
