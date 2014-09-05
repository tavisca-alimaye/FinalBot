using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Infrastructure
{
    public static class DependencyContainerExtensions
    {
        public static IDependencyContainer Register<TInterface, TConcrete>(this IDependencyContainer container, string name = null)
        {
            return container.Register(typeof(TInterface), typeof(TConcrete), name);
        }
            

    }
}
