using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServicesManager
    {
        IOrderServices OrderServices { get; }
        IOrderItemServices OrderItemServices { get; }
        IProviderServices ProviderServices { get; }
    }
}
