using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
    public interface IResolver
    {
        object GetInstance(Type typeToGet);
        T Resolve<T>();
    }
}
