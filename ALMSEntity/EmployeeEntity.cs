using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    class EmployeeEntity
    {
        public int EmployeeID { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public long EmployeePhoneNumber { get; set; }
        public string EmployeeRole { get; set; }
        public int ManagerID { get; set; }
        public int ProjectID { get; set; }
    }
}
