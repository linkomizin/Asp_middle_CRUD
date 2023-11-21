using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public class ServiceManager : IServicesManager
    {

        private readonly Lazy<IOrderServices> _lazyOrderServices;
        private readonly Lazy<IOrderItemServices> _lazyOrderItemServices;
        private readonly Lazy<IProviderServices> _lazyProviderServices;



        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyOrderServices = new Lazy<IOrderServices>(() => new OrderService(repositoryManager));
            _lazyOrderItemServices = new Lazy<IOrderItemServices>(() => new OrderItemService(repositoryManager));
            _lazyProviderServices = new Lazy<IProviderServices>(() => new ProviderService(repositoryManager));
        }

        public IOrderServices OrderServices => _lazyOrderServices.Value;
        public IOrderItemServices OrderItemServices => _lazyOrderItemServices.Value;
        public IProviderServices ProviderServices => _lazyProviderServices.Value;

    }
}
