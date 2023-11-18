using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPeelable
    {
        public bool IsPeeled { get; }
        public void Peel();
    }
}
