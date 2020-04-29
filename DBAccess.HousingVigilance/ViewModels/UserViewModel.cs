using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public char UserType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AppartmentNumber { get; set; }
        public int ContactNumber1 { get; set; }
        public int ContactNumber2 { get; set; }
        public string PrimaryEmail { get; set; }      
        public int QRId { get; set; }
        public string QrUniqueId { get; set; }
        public byte[] QrCode { get; set; }
        public int RoleID { get; set; }       
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

    }
}
