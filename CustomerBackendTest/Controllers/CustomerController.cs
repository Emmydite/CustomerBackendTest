using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.BLL.Contracts;
using Customer.BLL.Models;
using Customer.BLL.Services;
using Customer.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CustomerBackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerServices;

        public CustomerController(ICustomerService customerServices)
        {
            _customerServices = customerServices;
        }

        // GET: get customers
        [HttpGet("getcustomers")]
        public async Task<List<CustomerModel>> Get()
        {
            return await _customerServices.GetCustomers();
        }


        // POST api/<CustomerController>
        [HttpPost("onboardcustomer")]
        public async Task<IActionResult> Post([FromBody] CustomerModel customer)
        {
            var customRes = new ResponseObj
            {
                Code = ResponseCodes.InvalidRequest
            };

            if (!ModelState.IsValid)
            {
                return Ok(customRes);
            }

            var createRes =  await _customerServices.CreateCustomer(customer);

            if (createRes)
            {
                customRes.Code = ResponseCodes.Ok;
                customRes.Message = "An OTP has been sent to your Phone Number. Verify to complete onboarding";

                return Ok(customRes);
            }

            return Ok(customRes);
        }


        [HttpGet("validateotp")]
        public async Task<IActionResult> ValidateCode(string code, string phone)
        {
            var response = await _customerServices.ValidateOTP(code, phone);

            return Ok(response);
        }


    }
}
