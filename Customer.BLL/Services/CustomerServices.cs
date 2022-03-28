using AutoMapper;
using Customer.BLL.Manager;
using Customer.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Customer.BLL.Models;
using Customer.BLL.Contracts;

namespace Customer.BLL.Services
{
   
   public class CustomerServices : ICustomerService
    {
        private readonly CustomerManager _customerManager;
        private readonly IMapper _mapper;

        public CustomerServices(CustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateCustomer(CustomerModel customer)
        {
            bool created = false;

            try
            {

                if (customer != null)
                {
                    var cust = new CustomerModel
                    {
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        PassWord = customer.PassWord,
                        StateOfResidence = customer.StateOfResidence,
                        Lga = customer.Lga
                    };

                    var mapCustomer = _mapper.Map<DAL.Entities.Customer>(cust);

                    var createCustomer = await _customerManager.CreateCustomer(mapCustomer);

                    if (createCustomer)
                    {
                        var sendOtp = ValidatePhone(customer.PhoneNumber);

                        created = true;

                        return created;
                    }
                }

                return created;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            try
            {

                var customers = await _customerManager.GetAllCustomers().Result.Select(c => new CustomerModel
                {
                    CustomerId = c.CustomerId,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    StateOfResidence = c.StateOfResidence,
                    Lga = c.Lga,
                    IsPhoneVerified = c.PhoneNumber_verified
                }).ToListAsync();

                return customers;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool ValidatePhone(string phone)
        {
            try
            {
                var validate_phone = OtpService.SendOTP(phone);

                if (validate_phone)
                    return true;
                else
                   return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ValidateOTP(string otpCode, string phone)
        {
            try
            {
                var isValidCode = OtpService.ValidateOPT(otpCode);

                if (isValidCode)
                {
                    var model = new CustomerModel
                    {
                        PhoneNumber = phone,
                        IsPhoneVerified = true
                    };

                    //update customer details to verified status
                    var mapCustomer = _mapper.Map<DAL.Entities.Customer>(model);
                    var updatePhoneVerified = await _customerManager.UpdateCustomer(mapCustomer);

                    return updatePhoneVerified;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
