using CinemaBookingClient.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CinemaBookingClient.Services
{
    public class CinemaSeatPlanWS : ICinemaSeatPlanWS
    {
        private IConfiguration Configuration { get; } 

        public CinemaSeatPlanWS(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<CinemaSeatPlan> GetCinemaSeatPlanAsync()
        {           
            using (var client = new HttpClient())
            {
                var url = new Uri(Configuration.GetConnectionString("WebServiceConnection"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var sketch = JsonConvert.DeserializeObject<CinemaSeatPlan>(json);
                if (!string.IsNullOrEmpty(sketch.ErrorDescription))
                    throw new ApplicationException($"Error when getting data from Scheme service: {sketch.ErrorDescription}");
                return sketch;
            }          
        }
    }
}
