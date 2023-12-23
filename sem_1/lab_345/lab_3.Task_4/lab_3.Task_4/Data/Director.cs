using lab_3.Task_4.Data.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_4.Data
{
    public class Director
    {
        private ReservoirBuilder _builder;
        public ReservoirBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildFullFeaturedProduct()
        {
            _builder.BuildPit();
            _builder.FillPit();
            _builder.Plant();
            _builder.PutInhabitants();
        }
    }
}