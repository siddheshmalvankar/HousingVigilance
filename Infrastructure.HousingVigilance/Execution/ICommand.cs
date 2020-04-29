using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
    public interface ICommand  {    }
    public interface ICommand<out TResult> : ICommand { }
}
