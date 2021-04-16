using CustomerDetailsService.Models.Domains;

namespace CustomerDetailsService.Strategies
{
    public interface ICustomerDetailsStrategy
    {
        DomainCustomer SetAgeDetail();
    }
}
