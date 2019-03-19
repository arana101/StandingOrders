using StandingOrders.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace StandingOrders.Pages
{
    public abstract class MembersPageAsserter : BasePageAsserter<MembersPageMap>
    {
        public abstract void VerifyMenuItems();
    }

    public class EmployeeAdminMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(7, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Admin user");

            var page = new EmployeeAdminMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeSupervisorMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(8, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Supervisor user");

            var page = new EmployeeSupervisorMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeCallTakerMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Call Taker user");

            var page = new EmployeeCallTakerMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeCredentialingMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Credentialing user");

            var page = new EmployeeCredentialingMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeDispatcherMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(7, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Dispatcher user");

            var page = new EmployeeDispatcherMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeBillerMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(6, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Employee Biller user");

            var page = new EmployeeBillerMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminPPMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer Admin Payer Portal user");

            var page = new PayerAdminPPMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminTSMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer Admin Trip Scheduler user");

            var page = new PayerAdminTSMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminTSROMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer Admin Trip Scheduler Read Only user");

            var page = new PayerAdminTSROMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserPPMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer User Payer Portal user");

            var page = new PayerUserPPMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserTSMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer User Trip Scheduler user");

            var page = new PayerUserTSMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserTSROMembersPageAsserter : MembersPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MembersMenuItems.Count, "Incorrect number of Members menu items for Payer User Trip Scheduler Read Only user");

            var page = new PayerUserTSROMembersPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MembersMenuItems)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }
}
