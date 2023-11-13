using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contarcts
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Quautity { get; set; }
        public string Unit { get; set; }
    }
}
