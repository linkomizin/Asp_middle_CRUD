using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contarcts
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
