using StandingOrders.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace StandingOrders.Pages
{
    public class MembersPage<T, V> : BasePage<T, V>
        where T : BasePageElementMap, new()
        where V : BasePageAsserter<T>, new()
    {
        public MembersPage(string url) : base(url)
        {
        }

        public MembersPage()
        {
        }
    }



    public class EmployeeAdminMembersPage : MembersPage<MembersPageMap, EmployeeAdminMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/trip/root",
            "/report/report?id=7",
            "/grievances.aspx",
            "/memberuserapprove.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeAdminMembersPage() : base(@"")
        {

        }        

    }

    public class EmployeeSupervisorMembersPage : BasePage<MembersPageMap, EmployeeSupervisorMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/trip/root",
            "/report?id=18",
            "/report/report?id=7",
            "/report/report?id=19",
            "/grievances.aspx",
            "/memberlookup.aspx", 
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeSupervisorMembersPage() : base(@"")
        {

        }
    }

    public class EmployeeCallTakerMembersPage : BasePage<MembersPageMap, EmployeeCallTakerMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/trip/root",
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeCallTakerMembersPage() : base(@"")
        {

        }
    }

    public class EmployeeCredentialingMembersPage : BasePage<MembersPageMap, EmployeeCredentialingMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberuserapprove.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeCredentialingMembersPage() : base(@"")
        {

        }
    }

    public class EmployeeDispatcherMembersPage : BasePage<MembersPageMap, EmployeeDispatcherMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/trip/root",
            "/report/report?id=7",
            "/grievances.aspx",
            "/memberuserapprove.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeDispatcherMembersPage() : base(@"")
        {

        }
    }

    public class EmployeeBillerMembersPage : BasePage<MembersPageMap, EmployeeBillerMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/trip/root",
            "/grievances.aspx",
            "/memberuserapprove.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public EmployeeBillerMembersPage() : base(@"")
        {

        }
    }

    public class PayerAdminPPMembersPage : BasePage<MembersPageMap, PayerAdminPPMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerAdminPPMembersPage() : base(@"")
        {

        }
    }

    public class PayerAdminTSMembersPage : BasePage<MembersPageMap, PayerAdminTSMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerAdminTSMembersPage() : base(@"")
        {

        }
    }

    public class PayerAdminTSROMembersPage : BasePage<MembersPageMap, PayerAdminTSROMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerAdminTSROMembersPage() : base(@"")
        {

        }
    }

    public class PayerUserPPMembersPage : BasePage<MembersPageMap, PayerUserPPMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerUserPPMembersPage() : base(@"")
        {

        }
    }

    public class PayerUserTSMembersPage : BasePage<MembersPageMap, PayerUserTSMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerUserTSMembersPage() : base(@"")
        {

        }
    }

    public class PayerUserTSROMembersPage : BasePage<MembersPageMap, PayerUserTSROMembersPageAsserter>
    {
        public List<string> Links = new List<string>
        {
            "/grievances.aspx",
            "/memberlookup.aspx",
            "/memberlookup.aspx",
            "/manifest.aspx"
        };

        public PayerUserTSROMembersPage() : base(@"")
        {

        }
    }
}
