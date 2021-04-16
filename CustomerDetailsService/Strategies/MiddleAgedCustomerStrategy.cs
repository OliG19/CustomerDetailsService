using CustomerDetailsService.Models.Domains;

namespace CustomerDetailsService.Strategies
{
    public class MiddleAgedCustomerStrategy : ICustomerDetailsStrategy
    {
        private readonly DomainCustomer _customer;
        public MiddleAgedCustomerStrategy(DomainCustomer customer)
        {
            _customer = customer;
        }
        public DomainCustomer SetAgeDetail()
        {
            _customer.AgeDetail = "The person is classed as middle aged.";

            return _customer;
        }
    }
}
