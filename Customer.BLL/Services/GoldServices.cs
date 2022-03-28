using Customer.BLL.Contracts;
using Customer.BLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BLL.Services
{
   public class GoldServices : IGoldService
    {
       public GoldServices()
        {

        }


        public async Task<MetalRespponse> GetGoldPrice()
        {
            var goldPrice = new MetalRespponse();

            //var baseUrl = "https://rapidapi.com/ai-box-ai-box-default/api/gold-price-live/";

            var baseUrl = "https://gold-price-live.p.rapidapi.com/get_metal_prices";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "gold-price-live.p.rapidapi.com");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "a47102cfd3msha59b32120ee5a38p15a532jsn8692b29bb0f8");

                    var response =  client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();                      
                        var res = await response.Content.ReadAsStringAsync();

                        goldPrice = JsonConvert.DeserializeObject<MetalRespponse>(res);
                    }

                    return goldPrice;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
