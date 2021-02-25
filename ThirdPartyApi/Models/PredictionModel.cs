using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdPartyApi.Models
{
    public class PredictionModel
    {
        public string Country { get; set; }
        public DateTime? Date { get; set; }
        public int Cases { get; set; }
    }
}
