using CustomerDetailsService.Models.Domains;
using CustomerDetailsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDetailsService.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetAsync(string name);
        Task SaveAsync(DomainCustomer domainCustomer);
        Task DeleteAsync(string name);
    }
}
