using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Order : BaseClass
    {
        public DateTime OrderTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
