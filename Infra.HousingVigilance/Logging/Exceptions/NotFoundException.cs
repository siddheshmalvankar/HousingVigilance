using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Logging.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public string Key { get; set; }
        public override string Message
        {
            get
            {
                return String.Format("Entity not found with Name {0} and key {1}", typeof(T).Name, Key);
            }
        }
        public NotFoundException(string key)
        {
            Key = key;
        }

        public NotFoundException(int key)
        {
            Key = key.ToString();
        }
    }
}
