using CustomerDetailsService.Models.Domains;

namespace CustomerDetailsService.Strategies
{
    public class YoungCustomerStrategy : ICustomerDetailsStrategy
    {
        private readonly DomainCustomer _customer;
        public YoungCustomerStrategy(DomainCustomer customer)
        {
            _customer = customer;
        }

        public DomainCustomer SetAgeDetail()
        {
            _customer.AgeDetail = "The person is classed as young.";

            return _customer;
        }
    }
}
