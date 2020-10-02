using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSExceptions
{
    /// <summary>
    /// Exception Class to catch the Exceptions occuring in Attendance Leave Management System(ALMS)
    /// Author: Amar Poddar
    /// DOC: 29th Oct 2020
    /// </summary>
    public class ALMSException : ApplicationException
    {
        //Default Constructor , that inherits the base constructor
        public ALMSException() : base() { }

        // Parameterized constructor for passing the Error/Exception Message
        public ALMSException(string Message) :
            base(Message)
        { }


    }
}
