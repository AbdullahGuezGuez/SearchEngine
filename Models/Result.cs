using SearchEngine.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    public class Result
    {
        public Service Service { get; set; }
        public double Distance { get; set; }
        public int Score { get; set; }
    }
}
