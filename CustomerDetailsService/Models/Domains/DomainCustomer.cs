using System;
using CustomerDetailsService.Strategies;
using Newtonsoft.Json;

namespace CustomerDetailsService.Models.Domains
{
    public class DomainCustomer
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string AgeDetail { get; set; }

        public ICustomerDetailsStrategy GetStrategy()
        {
            if (Age < 30)
            {
                return new YoungCustomerStrategy(this);
            }

            if (Age < 60)
            {
                return new MiddleAgedCustomerStrategy(this);
            }

            return new OldCustomerStrategy(this);
        }
    }
}
