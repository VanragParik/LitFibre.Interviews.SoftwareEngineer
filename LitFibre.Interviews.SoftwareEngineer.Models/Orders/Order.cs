using LitFibre.Interviews.SoftwareEngineer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitFibre.Interviews.SoftwareEngineer.Models.Orders
{
    public class Order : DatabaseObject
    {
        public override string Id { get; set; } = string.Empty;

        public double BasePrice { get; set; }

        public double Discount { get; set; }

        public double TotalPrice { get; set; }

        public List<string> ProductCodes { get; set; } = new();

        public DateTime OrderDate { get; set; }
    }
}
