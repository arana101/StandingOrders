using StandingOrders.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace StandingOrders.Pages
{
    public abstract class DashboardPageAsserter : BasePageAsserter<DashboardPageMap>
    {
        public abstract void VerifyMenuItems();
    }

    public class MethodsDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            throw new System.NotImplementedException();
        }

        public void CheckBlogPost()
        {
            var title = "Post created by automation test";
            var description = "This blog post was created by automation test";
            var postedBy = "Andrew Lomakin";
            var date = DateTime.Now.AddHours(2).ToString("d MMM, yyyy");
            string lastBlogPostText = null;

            try
            {
                Driver.Browser.SwitchTo().Frame("contentFrame");

                var blog = Driver.Browser.FindElement(By.Id("BlogWritingBind"));

                var lastBlogPost = blog.FindElements(By.TagName("div")).First();
                lastBlogPostText = lastBlogPost.Text;
                Assert.IsTrue(lastBlogPost.Text.CaseInsensitiveContains(title));
                Assert.IsTrue(lastBlogPost.Text.CaseInsensitiveContains(description));
                Assert.IsTrue(lastBlogPost.Text.CaseInsensitiveContains(postedBy));
                Assert.IsTrue(lastBlogPost.Text.CaseInsensitiveContains(date));
            }
            catch (AssertionException)
            {
                throw new AssertionException($"Incorrect blog post on Dashboard. Expected Title '{title}', " +
                                                $"Body '{description}', Posted By should contains '{postedBy}', " +
                                                $"Date {date}. Actual {lastBlogPostText}");
            }
            finally
            {
                Driver.Browser.SwitchTo().DefaultContent();
            }
        }
    }

    public class EmployeeAdminDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(7, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Admin user");

            var page = new EmployeeAdminDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeSupervisorDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Supervisor user");

            var page = new EmployeeSupervisorDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeCallTakerDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(3, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Call Taker user");

            var page = new EmployeeCallTakerDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeCredentialingDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Credentialing user");

            var page = new EmployeeCredentialingDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeDispatcherDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Dispatcher user");

            var page = new EmployeeDispatcherDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class EmployeeBillerDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(6, Map.MenuItemsLinks.Count, "Incorrect number of menues for Employee Biller user");

            var page = new EmployeeBillerDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminPPDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer Admin Payer Portal user");

            var page = new PayerAdminPPDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminTSDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(3, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer Admin Trip Scheduler user");

            var page = new PayerAdminTSDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerAdminTSRODashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(2, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer Admin Trip Scheduler Read Only user");

            var page = new PayerAdminTSRODashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserPPDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(4, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer User Payer Portal user");

            var page = new PayerUserPPDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserTSDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(2, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer User Trip Scheduler user");

            var page = new PayerUserTSDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class PayerUserTSRODashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(2, Map.MenuItemsLinks.Count, "Incorrect number of menues for Payer User Trip Scheduler Read Only user");

            var page = new PayerUserTSRODashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }

    public class ProviderUserDashboardPageAsserter : DashboardPageAsserter
    {
        public override void VerifyMenuItems()
        {
            Assert.AreEqual(5, Map.MenuItemsLinks.Count, "Incorrect number of menues for Provider User user");

            var page = new ProviderUserDashboardPage();
            var links = page.Links;

            int index = 0;
            foreach (IWebElement item in Map.MenuItemsLinks)
            {
                Helper.CheckItem(item, links[index], item.Displayed);
                index++;
            }
        }
    }
}
