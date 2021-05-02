using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    public class Service
    {


        public int id { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
        public class Position
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

    }


}
