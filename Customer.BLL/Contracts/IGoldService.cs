using Customer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BLL.Contracts
{
   public interface IGoldService
    {
        Task<MetalRespponse> GetGoldPrice();
    }
}
