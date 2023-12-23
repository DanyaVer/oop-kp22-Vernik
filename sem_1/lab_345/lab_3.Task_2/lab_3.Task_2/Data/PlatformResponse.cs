using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data
{
    public class PlatformResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public List<T> Result { get; set; }
    }
}
