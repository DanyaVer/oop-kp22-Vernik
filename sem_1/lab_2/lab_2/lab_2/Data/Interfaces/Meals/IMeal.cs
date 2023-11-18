using Data.Classes.Args;
using lab_2.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IMeal
    {
        public bool IsCooking { get; }
        public bool IsCooked { get; }

        public void CookFor(Mom mom, TimeEventArgs timeArgs);
        public void Cook(Mom mom);
    }
}
