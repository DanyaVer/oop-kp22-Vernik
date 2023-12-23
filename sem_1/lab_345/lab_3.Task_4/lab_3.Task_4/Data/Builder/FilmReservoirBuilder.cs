using lab_3.Task_4.Data.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data.Builder
{
    public class FilmReservoirBuilder : ReservoirBuilder
    {
        protected override ArtificialReservoir result { get; set; } = new FilmArtificialReservoir();

        public FilmReservoirBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            result = new FilmArtificialReservoir();
        }

        public FilmArtificialReservoir GetProduct()
        {
            FilmArtificialReservoir product = (FilmArtificialReservoir)result;

            Reset();

            return product;
        }
    }
}
