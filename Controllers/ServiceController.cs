using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geolocation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SearchEngine.App_Data;
using SearchEngine.Dtos;
using SearchEngine.Models;

namespace SearchEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly List<Service> _services;

        public ServiceController()
        {
            _services = JsonConvert.DeserializeObject<List<Service>>(System.IO.File.ReadAllText("App_Data/data.json"));
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchedServicesAsync([FromQuery] string name, [FromQuery] double lat, [FromQuery] double lng)
        {
            SearchServiceDto sSDto = new SearchServiceDto { Name = name, Position = new Position { Lat = lat, Lng = lng } };
            SearchResultDto searchResult = new SearchResultDto(); 

            Coordinate origin = new Coordinate(sSDto.Position.Lat, sSDto.Position.Lng);

            List<Result> serviceSearchResult = new List<Result>();
            int totalServiceFound = 0;
            int totalSearchedServices = 0;

            foreach (var service in _services)
            {
                Coordinate destination = new Coordinate(service.Position.Lat, service.Position.Lng);
                totalSearchedServices++;
                
                if(service.Name.ToUpper().Contains(name.ToUpper()) || name.ToUpper() == service.Name.ToUpper())
                {
                    Result result = new Result();
                    result.Service = service;

                    totalServiceFound++;


                    if(name.ToUpper() == service.Name.ToUpper())
                    {
                        result.Score += 10;
                    }
                    if (service.Name.ToUpper().Contains(name.ToUpper())) 
                    {
                        result.Score += 5;
                    }
                    result.Distance = GeoCalculator.GetDistance(origin, destination, 15, DistanceUnit.Kilometers);

                    serviceSearchResult.Add(result);
                }

            }

            searchResult.TotalHits = totalServiceFound;
            searchResult.TotalDocuments = totalSearchedServices;
            searchResult.Results = serviceSearchResult;



            return Ok(searchResult);
        }






    }
}
