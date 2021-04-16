using CustomerDetailsService.Models.Domains;
using CustomerDetailsService.Models.Entities;
using CustomerDetailsService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDetailsService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<EntityCustomer> _customerRepository;

        public CustomerService(IRepository<EntityCustomer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<DomainCustomer> GetAll()
        {
            var entityCustomerList =  _customerRepository.GetAll();

            var listOfCustomers = new List<DomainCustomer>();

            foreach (var entityCustomer in entityCustomerList)
            {
                var customer = CreateCustomer(entityCustomer);

                listOfCustomers.Add(customer);
            }

            return listOfCustomers;
        }

        public async Task<DomainCustomer> GetCustomerByName(string name)
        {
            var entityCustomer = await _customerRepository.GetAsync(name);

            var customer = CreateCustomer(entityCustomer);

            return customer;
        }

        public async Task SaveAsync(DomainCustomer customer)
        {
            await _customerRepository.SaveAsync(customer);
        }

        public async Task DeleteAsync(string name)
        {
            await _customerRepository.DeleteAsync(name);
        }

        private static DomainCustomer CreateCustomer(EntityCustomer entityCustomer)
        {
            var customer = new DomainCustomer
            {
                Name = entityCustomer.Name,
                Age = entityCustomer.Age
            };
            var strategy = customer.GetStrategy();

            customer = strategy.SetAgeDetail();

            return customer;
        }
    }
}
