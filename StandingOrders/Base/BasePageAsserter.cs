namespace StandingOrders.Base
{
    public class BasePageAsserter<T>
        where T : BasePageElementMap, new()
    {
        protected T Map
        {
            get
            {
                return new T();
            }
        }
    }
}
