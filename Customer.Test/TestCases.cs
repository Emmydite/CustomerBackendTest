using Customer.BLL.Contracts;
using Customer.BLL.Models;
using CustomerBackendTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Test
{
    public class TestCases
    {
        public Mock<ICustomerService> mock = new Mock<ICustomerService>();
        public Mock<IGoldService> goldMock = new Mock<IGoldService>();


        [Fact]
        public async void CreateCustomer()
        {
            var customerDTO = new CustomerModel()
            {

                Email = "emmy@gmail.com",
                PhoneNumber = "07035663786",
                StateOfResidence = "Lagos",
                Lga = "LAG",
                IsPhoneVerified = false,
                PassWord = "meee"
            };

            mock.Setup(p => p.CreateCustomer(customerDTO)).ReturnsAsync(true);
            CustomerController cus = new CustomerController(mock.Object);
            var response = await cus.Post(customerDTO);
            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetCustomers()
        {
            var customerDTO = new List<CustomerModel>()
            {
               new CustomerModel
               {
                Email = "emmy@gmail.com",
                PhoneNumber = "07035663786",
                StateOfResidence = "Lagos",
                Lga = "LAG",
                IsPhoneVerified = false,
                PassWord = "meee"
               },

               new CustomerModel
               {
                Email = "emmry@gmail.com",
                PhoneNumber = "0703500000",
                StateOfResidence = "Abuja",
                Lga = "ABJ",
                IsPhoneVerified = false,
                PassWord = "meeerrr"
               },
            };

            mock.Setup(p => p.GetCustomers()).ReturnsAsync(customerDTO);
            CustomerController cus = new CustomerController(mock.Object);
            var result = await cus.Get();

            Assert.True(customerDTO.Equals(result));
        }

        [Fact]
        public async void ValidateOTP()
        {
            var code = "1234";
            var phone = "07000000000";

            mock.Setup(p => p.ValidateOTP(code, phone)).ReturnsAsync(true);
            CustomerController cus = new CustomerController(mock.Object);
            var response = await cus.ValidateCode(code, phone);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }


        [Fact]
        public async void GetGoldPrice()
        {
            var res = new MetalRespponse
            {
                gold = "1200"
            };

            goldMock.Setup(p => p.GetGoldPrice()).ReturnsAsync(res);
            GoldPriceController gold = new GoldPriceController(goldMock.Object);
            var response = await gold.GetGoldPrice();

            Assert.True(res.Equals(response));
        }
    }
}
