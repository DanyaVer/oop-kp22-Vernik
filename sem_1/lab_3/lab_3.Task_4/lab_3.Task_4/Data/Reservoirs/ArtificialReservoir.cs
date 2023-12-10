using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data.Reservoirs
{
    public abstract class ArtificialReservoir
    {
        public string PitType { get; set; }
        public bool IsBuildPit { get; set; }
        public bool IsFilled { get; set; }
        public string FilledWith { get; set; } = "Water";
        public bool ContainsPlants { get; set; }
        public bool ContainsInhabitants { get; set; }
    }
}
