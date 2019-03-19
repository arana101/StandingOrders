namespace StandingOrders.Base
{
    public class BasePage<T>
        where T : BasePageElementMap, new()
    {
        protected readonly string Url;

        private static BasePage<T> _instance;

        public BasePage(string url)
        {
            Url = url;
        }

        public BasePage()
        {
            Url = null;
        }

        public static BasePage<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BasePage<T>();
                }

                return _instance;
            }
        }

        protected T Map
        {
            get
            {
                return new T();
            }
        }

        public virtual void Navigate(string part = "")
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(Url, part));
        }
    }

    public class BasePage<T, V> : BasePage<T>
        where T : BasePageElementMap, new()
        where V : BasePageAsserter<T>, new()
    {
        public BasePage(string url) : base(url)
        {
        }

        public BasePage()
        {
        }

        public V Validate()
        {
            return new V();
        }
    }
}
