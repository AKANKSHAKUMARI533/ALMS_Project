using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    class LeaveEntity
    {
        public int LeaveRequestID { get; set; }
        public string LeaveType { get; set; }
        public int NoOfDays { get; set; }
        public int LeaveBalance { get; set; }
        public DateTime Leave_Date_From { get; set; }
        public DateTime LeaveDateTo { get; set; }
        public string LeaveStatus { get; set; }
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
    }
}
