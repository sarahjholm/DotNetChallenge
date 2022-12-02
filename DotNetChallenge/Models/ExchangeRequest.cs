using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Models
{
    public class ExchangeRequest
    {
        public string apiKey { get; set; }
        public string currencyFrom { get; set; }
        public string currencyTo { get; set; }
        public double amount { get; set; } = 1;
    }
}
