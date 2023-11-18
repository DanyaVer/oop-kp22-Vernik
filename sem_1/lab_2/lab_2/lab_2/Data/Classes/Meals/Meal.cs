using Data.Classes.Args;
using Data.Interfaces;
using lab_2.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Meals
{
    public abstract class Meal : IMeal
    {
        public bool IsCooking { get; protected set; }
        public bool IsCooked { get; protected set; }

        public void Cook(Mom mom)
        {
            throw new NotImplementedException();
        }

        public void CookFor(Mom mom, TimeEventArgs timeArgs)
        {
            throw new NotImplementedException();
        }
    }
}
