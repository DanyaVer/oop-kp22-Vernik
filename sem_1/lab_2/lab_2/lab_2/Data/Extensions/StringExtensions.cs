using Data.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class StringExtensions
    {
        public static TimeSpan GetTime(this string? str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException(nameof(str));
            // 12:12
            int[] values = str.Split(":").Select(x => int.Parse(x)).ToArray();
            if (values.Length > 5 || values.Length == 0)
                throw new TimeFormatException(nameof(str), str);

            if (values.Length == 1)
                return new TimeSpan(0, 0, values[0]);
            else if (values.Length == 2)
                return new TimeSpan(0, values[0], values[1]);
            else if (values.Length == 3)
                return new TimeSpan(values[0], values[1], values[2]);
            else if (values.Length == 4)
                return new TimeSpan(values[0], values[1], values[2], values[3]);
            else if (values.Length == 5)
                return new TimeSpan(values[0], values[1], values[2], values[3], values[4]);
            
            throw new TimeFormatException(nameof(str), str);
        }
    }
}
