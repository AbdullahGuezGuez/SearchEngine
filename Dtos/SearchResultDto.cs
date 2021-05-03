using SearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Dtos
{
    public class SearchResultDto
    {
        public int TotalHits { get; set; }
        public int TotalDocuments { get; set; }
        public List<Result> Results { get; set; }
    }
}
