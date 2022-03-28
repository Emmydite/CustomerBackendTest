using Customer.DAL.Contexts;
using Customer.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BLL.Manager
{
   public class CustomerManager : BaseManager<DAL.Entities.Customer>
    {
        public CustomerManager(CustomerDbContext context) : base(context)
        {

        }

        public async Task<bool> CreateCustomer(DAL.Entities.Customer customer)
        {
            return await this.AddAsync(customer);
        }

        public async Task<IQueryable<DAL.Entities.Customer>> GetAllCustomers()
        {
            return await this.GetAllAsync();
        }

        public async Task<bool> UpdateCustomer(DAL.Entities.Customer customer)
        {
            //update customer details to verified status
            var getCustomer =  this.GetAsync(c => c.PhoneNumber == customer.PhoneNumber && c.PhoneNumber_verified == false).Result;

            getCustomer.PhoneNumber_verified = true;

           var updated = await this.UpdateAsync(getCustomer);

            return updated;

        }
    }
}
