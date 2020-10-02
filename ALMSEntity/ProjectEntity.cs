using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    public class ProjectEntity
    {
        public int ProjectID { get; set; }
        public string Project_Name { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public string ProjectDetails { get; set; }

    }
}
