using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFryable
    {
        public bool IsFried { get; }
        public bool IsBurnt { get; }
        public void Fry();
    }
}
