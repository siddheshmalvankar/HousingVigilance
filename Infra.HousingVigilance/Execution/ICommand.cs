using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public interface ICommand  {    }
    public interface ICommand<out TResult> : ICommand { }
}
