using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitFibre.Interviews.SoftwareEngineer.Models.Orders
{
    public class ApiResponse
    {
        public string? Status { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public object? Data { get; set; }
    }
}
