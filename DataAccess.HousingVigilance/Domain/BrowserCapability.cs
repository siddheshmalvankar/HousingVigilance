using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public partial class BrowserCapability
    {
        public int BrowserCapabilityID { get; set; }
        public string BrowserType { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string BrowserMajorVersion { get; set; }
        public string BrowserMinorVersion { get; set; }
        public string Platform { get; set; }
        public Nullable<bool> IsBeta { get; set; }
        public Nullable<bool> IsCrawler { get; set; }
        public Nullable<bool> IsAOL { get; set; }
        public Nullable<bool> IsWin16 { get; set; }
        public Nullable<bool> IsWin32 { get; set; }
        public Nullable<bool> BrowserSupportFrames { get; set; }
        public Nullable<bool> BrowserSupportTables { get; set; }
        public Nullable<bool> BrowserSupportCookies { get; set; }
        public Nullable<bool> BrowserSupportVBScript { get; set; }
        public string BrowserJavaScriptVersion { get; set; }
        public Nullable<bool> BrowserSupportJavaApplets { get; set; }
        public Nullable<bool> BrowserSupportActiveXControls { get; set; }
        public Nullable<int> ApplicationUserID { get; set; }
        public string IPAddress { get; set; }
        public string UserLanguages { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
