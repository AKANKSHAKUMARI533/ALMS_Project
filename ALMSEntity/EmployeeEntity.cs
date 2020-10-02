using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    public class EmployeeEntity
    {
        public int EmployeeID { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeRole { get; set; }
        public string EmployeeStatus { get; set; }
        public int ManagerID { get; set; }
        public int ProjectID { get; set; }
    }
}
