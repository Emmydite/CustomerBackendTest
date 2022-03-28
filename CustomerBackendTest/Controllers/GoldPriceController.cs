using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.BLL.Contracts;
using Customer.BLL.Models;
using Customer.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerBackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldPriceController : ControllerBase
    {

        private readonly IGoldService _goldServices;

        public GoldPriceController(IGoldService goldServices)
        {
            _goldServices = goldServices;
        }
        // GET: api/<GoldPriceController>
        [HttpGet]
        public async Task<MetalRespponse> GetGoldPrice()
        {
            return await _goldServices.GetGoldPrice();
        }

    }
}
