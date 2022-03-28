using Customer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BLL.Contracts
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(CustomerModel customer);
        Task<List<CustomerModel>> GetCustomers();
        bool ValidatePhone(string phone);
        Task<bool> ValidateOTP(string otpCode, string phone);
    }
}
