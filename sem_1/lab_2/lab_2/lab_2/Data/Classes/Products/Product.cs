using Data.Classes.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Products
{
    public abstract class Product : IDisposable
    {
        protected Guid Id { get; }
        public string Name { get; protected set; }
        public string Origin { get; protected set; }
        /// <summary>
        /// indicates the price of this product in hrn
        /// </summary>
        private double _price;
        public double Price { 
            get
            {
                return Math.Round(_price, 2);
            }
            protected set { if (value > 0) _price = value; }
        }
        /// <summary>
        /// indicates the weight of this product in gram
        /// </summary>
        private double _weight;
        public double Weight {
            get
            {
                return Math.Round(_weight, 3);
            }
            protected set { if (value > 0) _weight = value; }
        }
        public byte DaysOfLife { get; protected set; }
        public byte MaxDaysOfLife { get; }
        public bool IsEatable
        {
            get
            {
                return ActualBoilTime > MinBoilTime && ActualBoilTime < MaxBoilTime && DaysOfLife < MaxDaysOfLife;
            }
        }
        private bool _isSpoiled;
        public bool IsSpoiled
        {
            get
            {
                return _isSpoiled || DaysOfLife > MaxDaysOfLife;
            }
            set
            {
                _isSpoiled = value;
            }
        }

        public bool IsCooking { get; set; }
        public virtual bool IsCooked 
        { 
            get
            {
                return ActualBoilTime > MinBoilTime && ActualBoilTime < MaxBoilTime;
            }
        }
        
        public readonly TimeSpan MinBoilTime;
        public readonly TimeSpan MaxBoilTime;
        public TimeSpan ActualBoilTime { get; set; }

        private Product()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product private constructor", Id));
            Id = Guid.NewGuid();
            ActualBoilTime = TimeSpan.Zero;
            DaysOfLife = 0;
        }
        protected Product(string name, double weight, double price, TimeSpan minBoilTime, TimeSpan maxBoilTime, string origin = "Ukraine", byte maxDaysOfLife = 7)
            : this()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product protected constructor", Id));
            if (minBoilTime > maxBoilTime)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Exiting Product protected constructor because of validation", Id));
                return;
            }
            Name = name;
            Weight = weight;
            Price = price;
            Origin = origin;
            MinBoilTime = minBoilTime;
            MaxBoilTime = maxBoilTime;
            MaxDaysOfLife = maxDaysOfLife;
        }

        public void BoilFor(TimeSpan timeSpan)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product BoilFor", Id));
            ActualBoilTime += timeSpan;
        }

        public void AddToSoup(Soup soup)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product AddToSoup", Id));
            soup.AddProduct(this);
        }
        public abstract bool IsReadyToCook();

        // false by default
        protected bool isDisposed;

        public void Dispose()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product Dispose", Id));
            Dispose(true);
            GC.SuppressFinalize(this);
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
                    Name = null;
                    Weight = 0;
                    Price = 0;
                    Origin = null;
                    IsSpoiled = false;
                }

                // set the bool value to true 
                isDisposed = true;
            }
        }
        ~Product()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Product destructor", Id));
            Dispose(false);
        }
    }
}
