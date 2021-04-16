using CustomerDetailsService.Models.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDetailsService.Services
{
    public interface ICustomerService
    {
        IEnumerable<DomainCustomer> GetAll();

        Task<DomainCustomer> GetCustomerByName(string name);

        Task SaveAsync(DomainCustomer customer);

        Task DeleteAsync(string name);
    }
}
