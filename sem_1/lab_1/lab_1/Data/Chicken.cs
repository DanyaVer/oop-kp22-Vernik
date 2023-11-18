using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Chicken : Meat
    {
        public bool IsBoiled { get; private set; }
        public Chicken(double weight, double price = 240, string origin = "Ukraine", byte maxDaysOfLife = 14)
            : base("Chicken", weight, price, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15), origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Chicken public constructor", Id));
        }
        public new bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Chicken new IsReadyToCook", Id));
            // because it can be cooked not being sliced
            return IsThawed && SaltLevel > 0;
        }
        protected virtual void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Product Dispose(bool) if (!isDisposed)", Id));
                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Product Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here
                    IsBoiled = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Chicken()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Chicken destructor", Id));
        }
    }
}
