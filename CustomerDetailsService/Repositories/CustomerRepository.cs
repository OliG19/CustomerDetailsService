using CustomerDetailsService.DAL;
using CustomerDetailsService.Exceptions;
using CustomerDetailsService.Models.Domains;
using CustomerDetailsService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDetailsService.Repositories
{
    public class CustomerRepository : IRepository<EntityCustomer>
    {
        private CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public IEnumerable<EntityCustomer> GetAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch
            {
                throw new NotFoundException("No Customers currently exists");
            }
        }

        public async Task<EntityCustomer> GetAsync(string name)
        {
            try
            {
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(m => m.Name == name);

                return customer;
            }
            catch
            {
                throw new NotFoundException($"Customer {name} does not exist");
            }
        }

        public async Task SaveAsync(DomainCustomer domainCustomer)
        {
            var existingCustomer = await GetExistingCustomer(domainCustomer.Name);

            var newCustomerDetails = CreateCustomerEntity(domainCustomer);

            if (existingCustomer == null)
            {
                _context.Add(newCustomerDetails);
            }
            else
            {
                UpdateExistingCustomer(existingCustomer, newCustomerDetails);

                _context.Update(existingCustomer);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string name)
        {
            try
            {
                var customer = await GetExistingCustomer(name);

                _context.Customers.Remove(customer);

                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new NotFoundException(exception.Message);
            }
        }

        private static void UpdateExistingCustomer(EntityCustomer existingCustomer, EntityCustomer newCustomerDetails)
        {
            existingCustomer.Age = newCustomerDetails.Age;
            existingCustomer.Name = newCustomerDetails.Name;
        }

        private EntityCustomer CreateCustomerEntity(DomainCustomer domainCustomer)
            => new EntityCustomer
            {
                Id = Guid.NewGuid(),
                Age = domainCustomer.Age,
                Name = domainCustomer.Name
            };

        private async Task<EntityCustomer> GetExistingCustomer(string name)
            => await _context.Customers.SingleOrDefaultAsync(e => e.Name == name);
    }
}
