using System;
using CustomerDetailsService.Controllers;
using CustomerDetailsService.Models.Domains;
using CustomerDetailsService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CustomerDetailsServiceTests
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _controller;
        private readonly Mock<ICustomerService> _customerService;

        public CustomerControllerTests()
        {
            _customerService = new Mock<ICustomerService>();

            _controller = new CustomerController(_customerService.Object);
        }
        [Fact]
        public void GivenThereAreCustomers_WhenGetAll_ThenAllCustomersRetrieved()
        {
            var customers = new List<DomainCustomer>
            {
                new DomainCustomer
                {
                    Name = "Bob",
                    Age = 33,
                    AgeDetail = "This person is middle aged"
                },
                new DomainCustomer
                {
                    Name = "Sally",
                    Age = 23,
                    AgeDetail = "This person is middle aged"
                }
            };

            _customerService.Setup(_ => _.GetAll()).Returns(customers);

            var sut = _controller.GetAll();

            Assert.Contains(sut, c => c.Name == "Bob");
            Assert.Contains(sut, c => c.Name == "Sally");
            Assert.Equal(2, sut.Count());
        }

        [Fact]
        public async Task GivenValidCustomerName_WhenGet_ThenCustomerDetailsRetrieved()
        {
            var customerOne = new DomainCustomer
            {
                Name = "Bob",
                Age = 33,
                AgeDetail = "This person is middle aged"
            };

            _customerService.Setup(_ => _.GetCustomerByName(It.IsAny<string>())).ReturnsAsync(customerOne);

            var sut = await _controller.Get("Bob");

            var result = sut.Value;

            Assert.Equal("Bob", result.Name);
            Assert.Equal(33, result.Age);
            Assert.Equal("This person is middle aged", result.AgeDetail);
        }

        [Fact]
        public async Task GivenInValidCustomerName_WhenGet_ThenBadRequestResult()
        {
            var sut = await _controller.Get("Bob123");

            Assert.IsType<BadRequestResult>(sut.Result);
        }

        [Fact]
        public async Task GivenValidCustomerDetails_WhenCreate_ThenCustomerIsCreated()
        {
            var customer = new DomainCustomer
            {
                Name = "Bob",
                Age = 33
            };

            _customerService.Setup(_ => _.SaveAsync(customer));

            var result = await _controller.Create(customer);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GivenValidCustomerDetails_WhenDelete_ThenCustomerIsDeleted()
        {
            _customerService.Setup(_ => _.DeleteAsync(It.IsAny<string>()));

            var result = await _controller.Delete("Bob");

            Assert.IsType<NoContentResult>(result);
        }
    }
}
