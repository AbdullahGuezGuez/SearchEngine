using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SearchEngine.Dtos;
using SearchEngine.Models;

namespace SearchEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetServiceAsync([FromQuery] string name, [FromQuery] double lat, [FromQuery] double lng)
        {

            return Ok(name +" "+ lat +" "+ lng );
        }

    }
}
