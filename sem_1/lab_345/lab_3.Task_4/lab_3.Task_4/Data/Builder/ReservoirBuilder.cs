using lab_3.Task_4.Data.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data.Builder
{
    public abstract class ReservoirBuilder
    {
        public abstract ArtificialReservoir result { get; protected set; }
        public virtual void BuildPit()
        {
            if (result == null)
                throw new InvalidOperationException();
            result.IsBuildPit = true;
        }
        public virtual void FillPit() 
        {
            if (result == null)
                throw new InvalidOperationException();
            result.IsFilled = true; 
        }
        public virtual void Plant()
        {
            if (result == null)
                throw new InvalidOperationException();
            result.ContainsPlants = true; 
        }
        public virtual void PutInhabitants()
        {
            if (result == null)
                throw new InvalidOperationException();
            result.ContainsInhabitants = true; 
        }
    }
}
