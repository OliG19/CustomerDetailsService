using CustomerDetailsService.Models.Domains;

namespace CustomerDetailsService.Strategies
{
    public class OldCustomerStrategy : ICustomerDetailsStrategy
    {
        private readonly DomainCustomer _customer;
        public OldCustomerStrategy(DomainCustomer customer)
        {
            _customer = customer;
        }

        public DomainCustomer SetAgeDetail()
        {
            _customer.AgeDetail = "The person is classed as elderly.";

            return _customer;
        }
    }
}
