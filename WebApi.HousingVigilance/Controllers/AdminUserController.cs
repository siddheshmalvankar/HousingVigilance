using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.HousingVigilance;
using Infra.HousingVigilance.Execution;
using Infra.HousingVigilance.Logging;
using WebApi.HousingVigilance.Models;
using WebApi.HousingVigilance.Extensions;
using Microsoft.AspNetCore.Mvc;
using ExecService.HousingVigilance.Commands;
using Infra.HousingVigilance.Helpers;

namespace WebApi.HousingVigilance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController :BaseApiController
    {
        public AdminUserController(IMediator mediator, ILog log, IAuditLogger auditLogger) : base(mediator, log, auditLogger)
        {

        }

        #region Web End Points
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Adminvalue1", "Adminvalue1" };
        }
              

        [Route("InviteUser")]
        public async Task<StatusMessage> InviteUser(InviteUserModel model)
        {
            var result = new StatusMessage();
            if (!ModelState.IsValid)
            {
                result.IsSuccessful = false;
                result.Message = ModelState.GetErrorMessage();
                return result;
            }
            PasswordHasher objpassword = new PasswordHasher();
            var password = objpassword.HashPassword(GenerateRandomPassword(10));
            var user = new InviteUserCommand()
            {
                AppartmentNumber=model.AppartmentNumber,
                ContactNumber1=model.ContactNumber1,
                ContactNumber2=model.ContactNumber2,
                FirstName=model.FirstName,
                LastName=model.LastName,
                MiddleName=model.MiddleName,
                PasswordHash= password,
                PrimaryEmail=model.PrimaryEmail,
                RoleID=model.RoleID,
                UserType=model.UserType
            };
            return Mediator.Execute(user).Result;

        }

        #endregion

        #region Private Members
        private string GenerateRandomPassword(int length)
        {
            int intZero = '0';
            int intNine = '9';
            int intA = 'A';
            int intO = 'O';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strCaptchaString = "";

            Random random = new Random(System.DateTime.Now.Millisecond);

            while (intCount < length)
            {
                intRandomNumber = random.Next(intZero, intZ);
                if (((intRandomNumber > intZero) && (intRandomNumber <= intNine) || (intRandomNumber >= intA) && (intRandomNumber < intO) || (intRandomNumber > intO) && (intRandomNumber <= intZ)))
                {
                    strCaptchaString = strCaptchaString + (char)intRandomNumber;
                    intCount = intCount + 1;
                }
            }
            return strCaptchaString;
        }
        #endregion
    }
}