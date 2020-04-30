using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.ServiceLocation;

namespace Infra.HousingVigilance.Execution
{
    public class Resolver : IResolver
    {
        private readonly ServiceLocatorProvider _resolver;
        public Resolver(ServiceLocatorProvider resolver)
        {
            _resolver = resolver;
        }
        public object GetInstance(Type typeToGet)
        {
            return _resolver().GetInstance(typeToGet);
        }

        public T Resolve<T>()
        {
            return _resolver().GetInstance<T>();
        }
    }


    public class ServiceLocator : IResolver
    {
        private ServiceProvider _currentServiceProvider;
        private static ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
        }

        public static ServiceLocator Current
        {
            get
            {
                return new ServiceLocator(_serviceProvider);
            }
        }

        public static void SetLocatorProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetInstance(Type serviceType)
        {
            return _currentServiceProvider.GetService(serviceType);
        }

        public TService Resolve<TService>()
        {
            return _currentServiceProvider.GetService<TService>();
        }
    }
}
