using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Exceptions
{
    public class TimeFormatException : Exception
    {
        public string EnteredValue { get; set; } = "";
        public TimeFormatException()
            : base()
        {
        }
        public TimeFormatException(string message)
            : base(message)
        {
        }

        public TimeFormatException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public TimeFormatException(string message, string enteredValue)
            : base(message)
        {
            EnteredValue = enteredValue;
        }
        public TimeFormatException(string message, string enteredValue, Exception innerException)
            :  base(message, innerException)
        {
            EnteredValue = enteredValue;
        }

        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(EnteredValue))
                    return $"{base.Message} is not in a correct form";
                else    
                    return $"{base.Message} value: '{EnteredValue}' is not in a correct form";
            }
        }
    }
}
