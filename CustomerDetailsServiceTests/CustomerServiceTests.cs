using CustomerDetailsService.Models.Entities;
using CustomerDetailsService.Repositories;
using CustomerDetailsService.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CustomerDetailsServiceTests
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _service;
        private readonly Mock<IRepository<EntityCustomer>> _repository;

        public CustomerServiceTests()
        {
            _repository = new Mock<IRepository<EntityCustomer>>();

            _service = new CustomerService(_repository.Object);
        }

        [Fact]
        public async Task GivenValidCustomer_WhenGetCustomerByName_MapsCorrectAgeDetails()
        {
            var customer = new EntityCustomer
            {
                Name = "Bob",
                Age = 40
            };

            _repository.Setup(_ => _.GetAsync(It.IsAny<string>())).ReturnsAsync(customer);

            var sut = _service.GetCustomerByName("Bob");

            Assert.Equal("The person is classed as middle aged.", sut.Result.AgeDetail);
        }

        [Fact]
        public void GivenValidCustomer_WhenGetAll_MapsCorrectAgeDetails()
        {
            var customerList = new List<EntityCustomer>
            {
                new EntityCustomer
                {
                    Name = "Bob",
                    Age = 15
                }
            };

            _repository.Setup(_ => _.GetAll()).Returns(customerList);

            var sut = _service.GetAll();

            Assert.Equal("The person is classed as young.", sut.SingleOrDefault()?.AgeDetail);
        }

    }
}
