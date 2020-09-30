using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSDAL;
namespace ALMSBLL
{
    public class LoginBLL
    {
        LoginDAL loginDAL = new LoginDAL();
        public bool ValidateLoginBLL(int userId, string password, string user)
        {

            bool validateLogin = loginDAL.ValidateLoginDAL(userId, password, user);

            return validateLogin;
        }

        public bool IsManagerBLL(int userId)
        {
            bool isManager = loginDAL.IsManagerDAL(userId);
            return isManager;
        }
    }

    
}
