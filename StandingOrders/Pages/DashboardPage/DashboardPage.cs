using StandingOrders.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandingOrders.Pages
{
    public class DashboardPage : BasePage<DashboardPageMap,MethodsDashboardPageAsserter>
    {
        public DashboardPage() : base(@"")
        {

        }

        private Actions actions = new Actions(Driver.Browser);
        private WebDriverWait wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(Helper.IMPLICIT_WAIT_TIMEOUT));

        public MembersPageMap OpenMembersTab()
        {
            IWebElement elem = Map.Menu.FindElement(By.Id("menu_item_members_id"));

            Driver.CustomClick(elem);
            Driver.WaitForPageLoad(Helper.PAGE_LOAD_TIMEOUT);
            System.Threading.Thread.Sleep(2000);

            return new MembersPageMap();
        }

        public LoginPageMap Logout()
        {
            Driver.CustomClick(Map.Buttons[Map.Buttons.Count - 1]);
            Driver.WaitForPageLoad(Helper.PAGE_LOAD_TIMEOUT);

            return new LoginPageMap();
        }

        public void OpenHomeTab()
        {
            IWebElement elem = Map.Menu.FindElement(By.Id("menu_item_home_id"));

            Driver.CustomClick(elem);
            Driver.WaitForPageLoad(Helper.PAGE_LOAD_TIMEOUT);
            System.Threading.Thread.Sleep(2000);
        }
    }

    public class EmployeeAdminDashboardPage : BasePage<DashboardPageMap, EmployeeAdminDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            "/trip/root",
            "/dashboard/dashboard",
            "/configuration/index",
            "/report/reports?id=0",
            "/monitor/index",
            "/usermanagement/index"
        };

        public EmployeeAdminDashboardPage() : base(@"")
        {

        }
    }

    public class EmployeeSupervisorDashboardPage : BasePage<DashboardPageMap, EmployeeSupervisorDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/report/report?id=7",
            "/trip/root",
            "/providerview.aspx",
            "/monitor/index",
            "/createissuestojira.aspx"
        };

        public EmployeeSupervisorDashboardPage() : base(@"")
        {

        }
    }

    public class EmployeeCallTakerDashboardPage : BasePage<DashboardPageMap, EmployeeCallTakerDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "/trip/root",
            "/createissuestojira.aspx"
        };

        public EmployeeCallTakerDashboardPage() : base(@"")
        {

        }
    }

    public class EmployeeCredentialingDashboardPage : BasePage<DashboardPageMap, EmployeeCredentialingDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            "/grievances.aspx",
            "/providerview.aspx",
            "/createissuestojira.aspx"
        };

        public EmployeeCredentialingDashboardPage() : base(@"")
        {

        }
    }

    public class EmployeeDispatcherDashboardPage : BasePage<DashboardPageMap, EmployeeDispatcherDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            "/trip/root",
            //"/report/report?id=7",
            "/providerview.aspx",
            "/configuration/index",
            "/addcustommessage.aspx"
        };

        public EmployeeDispatcherDashboardPage() : base(@"")
        {

        }
    }

    public class EmployeeBillerDashboardPage : BasePage<DashboardPageMap, EmployeeBillerDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            "/trip/root",
            "/providerview.aspx",
            "/configuration/index",
            "/monitor/index",
            "/addcustommessage.aspx"
        };

        public EmployeeBillerDashboardPage() : base(@"")
        {

        }
    }

    public class PayerAdminPPDashboardPage : BasePage<DashboardPageMap, PayerAdminPPDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            "/grievances.aspx",
            "/providerview.aspx",
            "/monitor/index",
            "/usermanagement/index"
        };

        public PayerAdminPPDashboardPage() : base(@"")
        {

        }
    }

    public class PayerAdminTSDashboardPage : BasePage<DashboardPageMap, PayerAdminTSDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "/monitor/index",
            "javascript:;"
        };

        public PayerAdminTSDashboardPage() : base(@"")
        {

        }
    }

    public class PayerAdminTSRODashboardPage : BasePage<DashboardPageMap, PayerAdminTSRODashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "javascript:;"
        };

        public PayerAdminTSRODashboardPage() : base(@"")
        {

        }
    }

    public class PayerUserPPDashboardPage : BasePage<DashboardPageMap, PayerUserPPDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "/providerview.aspx",
            "/monitor/index",
            "/createissuestojira.aspx"
        };

        public PayerUserPPDashboardPage() : base(@"")
        {

        }
    }

    public class PayerUserTSDashboardPage : BasePage<DashboardPageMap, PayerUserTSDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "javascript:;"
        };

        public PayerUserTSDashboardPage() : base(@"")
        {

        }
    }

    public class PayerUserTSRODashboardPage : BasePage<DashboardPageMap, PayerUserTSRODashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard.aspx",
            //"/grievances.aspx",
            "javascript:;"
        };

        public PayerUserTSRODashboardPage() : base(@"")
        {

        }
    }

    public class ProviderUserDashboardPage : BasePage<DashboardPageMap, ProviderUserDashboardPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/dashboard/dashboard",
            "/report/report?id=13",
            "/driver.aspx",
            "/report/reports?id=0",
            "/report/report?id=17"
        };

        public ProviderUserDashboardPage() : base(@"")
        {

        }
    }
}
