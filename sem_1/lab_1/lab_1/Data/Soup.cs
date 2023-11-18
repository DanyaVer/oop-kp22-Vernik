using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Soup : IDisposable
    {
        private static Soup singleInstance = null;
        private Soup()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup private constructor", Id));
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }
        public static Soup SoupInstance { 
            get
            {
                Console.WriteLine(string.Format("{0, -60}", "Soup SoupInstance get property"));
                if (singleInstance == null)
                    singleInstance = new Soup();
                return singleInstance;
            }
        }

        protected Guid Id { get; }
        private List<Product> Products { get; set; }
        public double WaterVolume { get; private set; }
        public bool IsCooking { get; private set; }
        public bool IsCooked { get; private set; }

        /// <summary>
        /// Filters products by the specified type
        /// </summary>
        /// <typeparam name="T">Is either of Product Type or any inherited</typeparam>
        /// <returns>Returns a list of items of T Type that List of Products contains</returns>
        public List<T> GetItemsFromProducts<T>() where T : Product
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup GetItemsFromProducts", Id));
            return Products.Where(x => x is T).Select(x => (T)x).ToList();
        }
        public bool HasCarrot()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup HasCarrot", Id));
            return Products.Exists(x => x is Carrot);
        }
        public bool HasPotato()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup HasPotato", Id));
            return Products.Exists(x => x is Potato);
        }

        public bool HasMeat()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup HasMeat", Id));
            return Products.Exists(x => x is Meat);
        }
        public void AddWater(double waterVolume)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup AddWater", Id));
            WaterVolume += waterVolume;
        }
        public void AddProduct(Product product)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup AddProduct", Id));
            if (Products.Exists(x => x == product))
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Product is already added to soup", Id));
                return;
            }

            if (product.IsReadyToCook())
                Products.Add(product);
            else
                Console.WriteLine(string.Format("{0, -60} - {1}", "Product is not ready to cook", Id));
        }

        public void CookFor(TimeSpan time)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup CookFor", Id));
            if (WaterVolume <= 0) 
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Exiting Soup CookFor because of Water absence", Id));
                return;
            }
            foreach (Product product in Products)
                product.IsCooking = true;
            foreach (Product product in Products)
            {
                for (TimeSpan i = TimeSpan.Zero; i < time; i += TimeSpan.FromSeconds(1))
                    product.BoilFor(time);
            }
            foreach (Product product in Products)
                product.IsCooking = false;
        }
        public void Cook()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Cook", Id));
            CookFor(Products.Max(x => x.MinBoilTime));
        }

        // false by default
        private bool isDisposed;
        public void Dispose()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose", Id));
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Dispose(bool isDisposing)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool)", Id));
            // check if already disposed
            if (!isDisposed)
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool) if (!isDisposed)", Id));
                if (isDisposing)
                {
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    // free managed objects here 
                    IsCooked = false;
                    IsCooking = false;
                    WaterVolume = 0;
                }

                Products = null;
                singleInstance = null;

                // set the bool value to true 
                isDisposed = true;
            }
        }

        ~Soup()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup destructor", Id));
            Dispose(false);
        }
    }
}