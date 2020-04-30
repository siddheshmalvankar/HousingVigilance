using Infra.HousingVigilance;
using Infra.HousingVigilance.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecService.HousingVigilance.Commands
{
    public class InviteUserCommand : ICommand<StatusMessage>
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
        public int RoleID { get; set; }
        public string PasswordHash { get; set; }
    }
}
