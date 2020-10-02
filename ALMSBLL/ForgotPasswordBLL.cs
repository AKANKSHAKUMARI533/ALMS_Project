using ALMSDAL;
using ALMSEntity;
using ALMSExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALMSBLL
{
    public class ForgotPasswordBLL
    {
        
        ForgotPasswordDAL forgotPasswordDAL = new ForgotPasswordDAL();

        public string ForgotBLL(ForgotPasswordEntity forgotPasswordEntity)
        {
            
            if (validateEmail(forgotPasswordEntity))
            {
                string password = forgotPasswordDAL.ForgotDAL(forgotPasswordEntity);
                return password;
            }
            else
            {
                return "";
            }
        }

        public bool validateEmail(ForgotPasswordEntity forgotPasswordEntity)
        {
            bool ValidEmployee = true;
            StringBuilder message = new StringBuilder();
            Regex regex1 = new Regex("^[A-Za-z0-9*.]{1,50}@(gmail|yahoo|outlook|).(com|org|in|us|au|uk|co.in)$");
            String email = forgotPasswordEntity.EmployeeEmail;
            if (!regex1.IsMatch(email))
            {
                message.Append(Environment.NewLine + "Email should follow standards!!");
                ValidEmployee = false;
            }

            if (ValidEmployee == false)
            {
                throw new ALMSException(message.ToString());
            }
            return ValidEmployee;
        }
    }
}
