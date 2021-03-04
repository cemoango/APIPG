using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class StatsMovie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int releaseYear { get; set; }
        public Double watchDurationMs { get; set; }
    }
}
