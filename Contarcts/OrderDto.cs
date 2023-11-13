using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contarcts
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
