using ApiConnectionSql.code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace ApiConnectionSql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
           var returnvalue =JsonConvert.SerializeObject(Connect.Get());
            return returnvalue;
        }

        [HttpPost]
        public string Post([FromQuery] string name, string life)
        {
            Connect.Post(name, life);
            var returnvalue = JsonConvert.SerializeObject(Connect.Get());
            return returnvalue;
        }

        [HttpPut]
        public string Put([FromQuery] int id,string name, string life)
        {
            Connect.Put(id,name,life);
            var returnvalue = JsonConvert.SerializeObject(Connect.Get());
            return returnvalue;
        }

        [HttpDelete]
        public string Delete([FromQuery] int id)
        {
            Connect.Delete(id);
            var returnvalue = JsonConvert.SerializeObject(Connect.Get());
            return returnvalue;
        }
    }
}
