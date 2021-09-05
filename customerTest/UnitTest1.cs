using System;
using Xunit;
using customerAPI.Controllers;
using customerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace customerTest
{
    public class UnitTest1
    {
        CustomersController _controller;
        CustomerContext _context;

        public UnitTest1()
        {

            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseInMemoryDatabase("CustomerDb");
            _context = new CustomerContext(optionsBuilder.Options);
            _controller = new CustomersController(_context);
        }

        [Fact]
        public void TestPostCustomer_Ok()
        {
            var context = new Customer
            {
                Id = 1,
                FirstName = "Lucus",
                LastName = "Kim",
                DateOfBirth = new DateTime(2012, 11, 12)
            };
            var actionResult = _controller.PostCustomer(context);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

        [Fact]
        public void TestGetAllCustomer_Ok()
        {
            var actionResult = _controller.GetCustomers();

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void TestGetCustomer_Ok()
        {
            long idcheck = 1; 
            var actionResult = _controller.GetCustomer(idcheck);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

        [Fact]
        public void TestGateCustomerBasedName_ok()
        {
            string name = "Lucus";
            var actionResult = _controller.GetCustomerName(name);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

        [Fact]
        public void TestPutCustomer_ok()
        {
            var context = new Customer
            {
                Id = 1,
                FirstName = "DDur",
                LastName = "Kim",
                DateOfBirth = new DateTime(2012, 11, 12)
            };
            var actionResult = _controller.PutCustomer(1, context);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

        [Fact]
        public void TestGetCustomerName_ok()
        {
            var actionResult = _controller.GetCustomerName("DDur");
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

        [Fact]
        public void TestDeletCustomer_ok()
        {
            var actionResult = _controller.DeleteCustomer(1);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }

    }
}
