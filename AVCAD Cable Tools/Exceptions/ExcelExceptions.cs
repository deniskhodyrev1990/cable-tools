using System;
using System.Windows;

namespace AVCAD.Exceptions
{
    public class ExcelHeadersException: Exception
    {
        /// <summary>
        /// Small exception inherited from Exception class.
        /// </summary>
        /// <param name="message"></param>
        public ExcelHeadersException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
