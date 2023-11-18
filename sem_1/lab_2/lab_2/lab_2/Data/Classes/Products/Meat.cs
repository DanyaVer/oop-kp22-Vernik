using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Products
{
    abstract class Meat : Product, ISliceable
    {
        /// <summary>
        /// Temperature in C degrees
        /// </summary>
        public static double FreezeTemperature { get; protected set; }
        public static double ThawTemperature { get; protected set; }
        public double Temperature { get; protected set; }
        public bool IsThawed { get; protected set; }
        public bool IsFrozen { get; protected set; }
        public bool IsSliced { get; protected set; }
        public byte SaltLevel { get; protected set; }
        public bool IsMince { get; protected set; }
        public Meat(string name, double weight, double price, TimeSpan minBoilTime, TimeSpan maxBoilTime, string origin = "Ukraine", byte maxDaysOfLife = 14)
            : base(name, weight, price, minBoilTime, maxBoilTime, origin, maxDaysOfLife)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat public constructor", Id));
            Temperature = 3;
        }
        static Meat()
        {
            Console.WriteLine(string.Format("{0, -60}", "Meat static constructor"));
            FreezeTemperature = 3;
            ThawTemperature = 15;
        }
        public void Freeze()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Freeze", Id));
            Temperature = FreezeTemperature;
            IsFrozen = true;
            IsThawed = false;
        }
        public void Thaw()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Thaw", Id));
            Temperature = ThawTemperature;
            IsThawed = true;
            IsFrozen = false;
        }
        public void Slice()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat Slice", Id));
            IsSliced = true;
        }
        public void AddSalt()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat AddSalt", Id));
            SaltLevel++;
        }
        public void MakeMince()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat MakeMince", Id));
            IsMince = true;
        }
        public override bool IsReadyToCook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat IsReadyToCook", Id));
            return IsThawed && SaltLevel > 0 && (IsSliced || IsMince);
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

                    IsThawed = false;
                    IsFrozen = false;
                    IsSliced = false;
                    SaltLevel = 0;
                    IsMince = false;
                    Temperature = 0;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Meat()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Meat destructor", Id));
        }
    }
}
