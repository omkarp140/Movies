namespace Movies.Models.Common
{
    public interface IMovieAppContext
    {
        public CustomerInfo CustomerInfo { get; set; }

        void SetCustomerContext(CustomerInfo customerInfo);
    }
    public class MovieAppContext : IMovieAppContext
    {
        public CustomerInfo CustomerInfo { get; set; } = new CustomerInfo();

        public void SetCustomerContext(CustomerInfo customerInfo)
        {
            CustomerInfo = customerInfo;
        }
    }
}
