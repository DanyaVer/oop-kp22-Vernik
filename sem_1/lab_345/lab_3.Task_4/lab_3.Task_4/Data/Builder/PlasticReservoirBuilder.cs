using lab_3.Task_4.Data.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data.Builder
{
    public class PlasticReservoirBuilder : ReservoirBuilder
    {
        protected override ArtificialReservoir result { get; set; } = new PlasticArtificialReservoir();

        public PlasticReservoirBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            result = new PlasticArtificialReservoir();
        }

        public PlasticArtificialReservoir GetProduct()
        {
            PlasticArtificialReservoir product = (PlasticArtificialReservoir)result;

            Reset();

            return product;
        }
    }
}
