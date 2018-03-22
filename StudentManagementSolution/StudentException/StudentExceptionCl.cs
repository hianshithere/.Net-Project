using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentException
{
    public class StudentExceptionCl:ApplicationException
    {
        public StudentExceptionCl():base()
        {

        }

        public StudentExceptionCl(string message):base(message)
        {
        }

        public StudentExceptionCl(string message,Exception innerException):
            base(message,innerException)
        {

        }


    }
}
