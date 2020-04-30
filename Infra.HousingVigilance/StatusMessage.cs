using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance
{
    public class StatusMessage
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public string ResultID { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
