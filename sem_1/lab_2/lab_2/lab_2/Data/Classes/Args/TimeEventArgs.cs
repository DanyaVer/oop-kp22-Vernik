using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Args
{
    public class TimeEventArgs : EventArgs
    {
        public TimeSpan Time{ get; set; }
        public TimeEventArgs(TimeSpan time) 
        { 
            this.Time = time;
        }
        public TimeEventArgs() : this(new TimeSpan()) { }
    }
}
