using lab_3.Task_4.Data.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data.Builder
{
    public class ConcreteReservoirBuilder : ReservoirBuilder
    {
        protected override ArtificialReservoir result { get; set; } = new ConcreteArtificialReservoir();

        public ConcreteReservoirBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            result = new ConcreteArtificialReservoir();
        }

        public ConcreteArtificialReservoir GetProduct()
        {
            ConcreteArtificialReservoir product = (ConcreteArtificialReservoir)result;

            Reset();

            return product;
        }
    }
}
