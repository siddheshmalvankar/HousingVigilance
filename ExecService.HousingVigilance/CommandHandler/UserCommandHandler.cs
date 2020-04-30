using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.Domain.Interfaces;
using ExecService.HousingVigilance.Commands;
using Infra.HousingVigilance;
using Infra.HousingVigilance.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecService.HousingVigilance.CommandHandler
{
    public class UserCommandHandler : ICommandHandler<InviteUserCommand, StatusMessage>
    {
        IUnitofWork _unitofWork;
        public UserCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public ICommandResult<StatusMessage> Handle(InviteUserCommand command)
        {
            StatusMessage message = new StatusMessage();
            UserLogin objuserLogin = new UserLogin();
            message.IsSuccessful = false;
            try
            {
                objuserLogin.UserName = command.AppartmentNumber;
                objuserLogin.PasswordHash = command.PasswordHash;

                if (_unitofWork.Complete() > 0)
                {
                    var userLogin = _unitofWork.UserLogins.GetUserLoginByName(command.AppartmentNumber.Trim());

                    User objUser = new User();
                    objUser.AppartmentNumber = command.AppartmentNumber;
                    objUser.ContactNumber1 = command.ContactNumber1;
                    objUser.ContactNumber2 = command.ContactNumber2;
                    objUser.FirstName = command.FirstName;
                    objUser.MiddleName = command.MiddleName;
                    objUser.LastName = command.LastName;
                    objUser.PrimaryEmail = command.PrimaryEmail;
                    objUser.RoleID = command.RoleID;
                    objUser.UserLoginID = userLogin.UserLoginID;
                    _unitofWork.Complete();
                    message.IsSuccessful = true;
                    message.Message = "User Invitation Success";
                }

            }
            catch(Exception ex)
            {
                message.IsSuccessful = false;
                message.Message = "User Invitation Failed";
            }

            return CommandResult.OK(message);
        }
    }
}
