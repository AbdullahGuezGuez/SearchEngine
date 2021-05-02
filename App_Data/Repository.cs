using Newtonsoft.Json;
using SearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.App_Data
{
    public class Repository
    {
        private readonly List<Service> _services;

        public Repository()
        {
            _services = JsonConvert.DeserializeObject<List<Service>>(System.IO.File.ReadAllText("App_Data/data.json"));
        }
        
        public List<Service> getAllServices()
        {
            return _services;
        }
    }
}
