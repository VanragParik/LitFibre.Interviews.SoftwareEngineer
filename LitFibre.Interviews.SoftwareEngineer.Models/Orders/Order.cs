using LitFibre.Interviews.SoftwareEngineer.Models.Data;
using Newtonsoft.Json;


namespace LitFibre.Interviews.SoftwareEngineer.Models.Orders
{
    public class Order : DatabaseObject
    {

        [JsonProperty("id")]
        public override string Id { get; set; } = string.Empty;
        [JsonProperty("basePrice")]
        public double BasePrice { get; set; }
        [JsonProperty("discount")]
        public double Discount { get; set; }
        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
        [JsonProperty("productCodes")]
        public List<string> ProductCodes { get; set; } = new();
        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }
    }

    public class GetOrder
    {
        public GetOrder()
        {
            var json = File.ReadAllText("../orders.json");
            if (json != null)
            {
                var parentItem = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var a = parentItem["orders"];
                if (a != null)
                {
                    Orders = JsonConvert.DeserializeObject<List<Order>>(JsonConvert.SerializeObject(a));
                }
            }

        }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
