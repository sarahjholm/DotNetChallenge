using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Models
{
    public class ApiResponse
    {
        public int error { get; set; }
        public string error_message { get; set; }
        public double amount  { get; set; }
    }
}
