using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.HousingVigilance.Extensions
{
    public static class ModelStateExtension
    {
        /// <summary>
        /// Get Error Mesage for MVC Model State
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary dictionary)
        {
            string errmsg = "";
            foreach (var key in dictionary.Keys)
            {
                errmsg += dictionary[key].Errors.First().ErrorMessage + "<br/>";
            }

            return errmsg;
        }
    }
}
