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
        public override ArtificialReservoir result { get; protected set; } = new FilmArtificialReservoir();
    }
}
