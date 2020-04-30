using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.HousingVigilance.Models
{
    public class InviteUserModel
    {

        [Required(ErrorMessage ="User Type is blank")]
        [Display(Name = "User Type")]
        public char UserType { get; set; }
        [Required(ErrorMessage = "First Name is blank")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is blank")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Appartment Number is blank")]
        [Display(Name = "Appartment Number")]
        public string AppartmentNumber { get; set; }
        [Required(ErrorMessage = "Contact Number is blank")]
        [Display(Name = "Contact Number")]
        public int ContactNumber1 { get; set; }
        public int ContactNumber2 { get; set; }
        [Required(ErrorMessage = "Primary Email is blank")]
        [Display(Name = "Primary Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string PrimaryEmail { get; set; }
        public int RoleID { get; set; }
       
    }
}
