using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    public class AttendanceEntity
    {
        public int AttendanceID { get; set; }
        public string AttendanceType { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string StatusOfAttendance { get; set; }
        public DateTime StatusUpdateDate { get; set; }
        public int StatusUpdatedBy { get; set; }
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
    }
}
