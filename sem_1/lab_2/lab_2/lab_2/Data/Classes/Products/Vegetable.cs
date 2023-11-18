using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Products
{
    public abstract class Vegetable : Product, ISliceable
    {
        public Vegetable(string name, double weight, double price, TimeSpan minBoilTime, TimeSpan maxBoilTime, string origin = "Ukraine", byte maxDaysOfLife = 7)
            : base(name, weight, price, minBoilTime, maxBoilTime, origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable public constructor", Id));
        }
        public bool IsSliced { get; protected set; }
        public void Slice()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable Slice", Id));
            if (!IsSliced)
            {
                IsSliced = true;
            }
            else
                Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable is already sliced", Id));
        }
        public override bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable IsReadyToCook", Id));
            return IsSliced;
        }
        protected override void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable Dispose(bool) if (!isDisposed)", Id));
                base.Dispose(isDisposing);

                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here
                    IsSliced = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Vegetable()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Vegetable destructor", Id));
        }
    }
}
