using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Products
{
    class Carrot :  Vegetable
    {
        public Carrot(double weight, double price = 12, string origin = "Ukraine", byte maxDaysOfLife = 7)
            : base("Carrot", weight, price, TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(10), origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot public constructor", Id));
        }
        public bool IsGrated { get; private set; }
        public new bool IsEatable
        {
            get
            {
                return !(ActualBoilTime > MaxBoilTime || DaysOfLife > MaxDaysOfLife);
            }
        }
        public void Grate()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot Grate", Id));
            if (!IsGrated)
            {
                Weight *= 0.98;
                IsGrated = true;
            }
            else
                Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot is already grated", Id));
        }
        public override bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot IsReadyToCook", Id));
            return IsGrated || IsSliced;
        }
        protected override void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot Dispose(bool) if (!isDisposed)", Id));
                base.Dispose(isDisposing);

                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here
                    IsGrated = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Carrot()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Carrot destructor", Id));
        }
    }
}