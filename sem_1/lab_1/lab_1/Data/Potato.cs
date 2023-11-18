using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Potato : Vegetable
    {
        public Potato(double weight, double price = 15, string origin = "Ukraine", byte maxDaysOfLife = 8, bool isPeeled = false)
            : base("Potato", weight, price, TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(10), origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Potato public constructor", Id));
            IsPeeled = isPeeled;
        }
        public bool IsPeeled { get; private set; }
        public void Peel()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Potato Peel", Id));
            if (!IsPeeled) 
            { 
                Weight *= 0.95;
                IsPeeled = true;
            }
            else
                Console.WriteLine(string.Format("{0, -60} - {1}", "Potato is already peeled", Id));
        }
        public override bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Potato IsReadyToCook", Id));
            return IsPeeled && base.IsReadyToCook();
        }
        protected override void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Potato Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Potato Dispose(bool) if (!isDisposed)", Id));
                base.Dispose(isDisposing);

                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Potato Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here
                    IsPeeled = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Potato()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Potato destructor", Id));
        }
    }
}
