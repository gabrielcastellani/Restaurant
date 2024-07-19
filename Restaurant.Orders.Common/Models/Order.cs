using Restaurant.Orders.Common.Abstracts;

namespace Restaurant.Orders.Common.Models
{
    public class Order : ModelBase
    {
        public Guid CustomerID { get; set; }
        public object[] Products { get; set; }
    }
}
