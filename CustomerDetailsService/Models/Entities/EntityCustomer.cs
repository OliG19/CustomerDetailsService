using System;
using CustomerDetailsService.Strategies;

namespace CustomerDetailsService.Models.Entities
{
    public class EntityCustomer : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
