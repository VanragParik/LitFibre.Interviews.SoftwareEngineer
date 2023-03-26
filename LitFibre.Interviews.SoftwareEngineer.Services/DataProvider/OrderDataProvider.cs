using LitFibre.Interviews.SoftwareEngineer.Models.Orders;
using LitFibre.Interviews.SoftwareEngineer.Services.Interfaces;

namespace LitFibre.Interviews.SoftwareEngineer.Services.DataProvider
{
    public class OrderDataProvider : IMemoryDatabase<Order>
    {
        private static readonly List<Order> Orders = new GetOrder().Orders;

        public void Delete(string id)
        {
            var item = Read(id);
            if (item != null)
            {
                Orders.Remove(item);
            }
        }

        public void Delete(Order item)
        {
            Orders.Remove(item);
        }

        public void Push(Order item)
        {
            Orders.Add(item);
        }

        public IEnumerable<Order> Query(Predicate<Order> predicate)
        {
            return Orders.Where(o => predicate(o));
        }

        public Order Read(string id)
        {
            return Orders.FirstOrDefault(x => x.Id == id) ?? new Order();
        }

        public List<Order> GetAll()
        {
            return Orders;
        }


    }
}
