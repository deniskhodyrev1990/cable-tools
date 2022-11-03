using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Exceptions
{
    public class ExcelHeadersException: Exception
    {
        public ExcelHeadersException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
