using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Pork : Meat
    {
        public override bool IsCooked
        {
            get
            {
                return (IsFried || (ActualBoilTime > MinBoilTime && ActualBoilTime < MaxBoilTime)) && !IsBurnt;
            }
        }
        public bool IsFried { get; private set; }
        public bool IsBurnt { get; private set; }
        public Pork(double weight, double price = 220, string origin = "Ukraine", byte maxDaysOfLife = 12)
            : base("Pork", weight, price, TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(14), origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Pork public constructor", Id));
        }
        public void Fry()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Pork Fry", Id));
            if (IsFried)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Pork is burnt", Id));
                IsBurnt = true;
            }
            IsFried = true;
        }
        public override bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Pork IsReadyToCook", Id));
            return IsSliced && base.IsReadyToCook();
        }
        protected override void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Dispose(bool) if (!isDisposed)", Id));
                base.Dispose(isDisposing);

                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here

                    IsFried = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Pork()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Pork destructor", Id));
        }
    }
}
