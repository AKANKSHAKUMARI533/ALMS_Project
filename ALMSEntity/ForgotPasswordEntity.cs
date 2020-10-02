using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    public class ForgotPasswordEntity
    {
        public int EmployeeID { get; set; }

        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
    }
}
