using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CinemaBookingClient.Models;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace CinemaBookingClient.Services
{
    public class CinemaSeatPlanFromFile : ICinemaSeatPlanWS
    {
        private IConfiguration Configuration { get; }

        public CinemaSeatPlanFromFile(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<CinemaSeatPlan> GetCinemaSeatPlanAsync()
        {
            string path = Configuration.GetValue<string>("testSchemeFile");
            using (StreamReader r = new StreamReader(path))
            {
                string json = await r.ReadToEndAsync();
                var sketch = JsonConvert.DeserializeObject<CinemaSeatPlan>(json);
                if (!string.IsNullOrEmpty(sketch.ErrorDescription))
                    throw new ApplicationException($"Error when getting data from Scheme service: {sketch.ErrorDescription}");
                return sketch;
            } 
        }
    }
}
