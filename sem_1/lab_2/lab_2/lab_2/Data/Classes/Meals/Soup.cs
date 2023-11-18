using Data.Classes.Args;
using Data.Classes.Products;
using Data.Interfaces;
using lab_2.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes.Meals
{
    public class Soup : Meal, IDisposable, ISoup, IMeatSoup, IVegetableSoup
    {
        public Soup()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup private constructor", Id));
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }

        protected Guid Id { get; }
        protected List<Product> Products { get; set; }
        public double WaterVolume { get; protected set; }

        /// <summary>
        /// Filters products by the specified type
        /// </summary>
        /// <typeparam name="T">Is either of Product Type or any inherited</typeparam>
        /// <returns>Returns a list of items of T Type that List of Products contains</returns>
        List<T> ISoup.GetItemsFromProducts<T>() 
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup ISoup.GetItemsFromProducts", Id));
            return Products.Where(x => x is T).Select(x => (T)x).ToList();
        }
        List<T> IVegetableSoup.GetItemsFromProducts<T>()
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup IVegetableSoup.GetItemsFromProducts", Id));
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
        public void AddProduct(Vegetable vegetable)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup AddProduct", Id));
            if (Products.Exists(x => x == vegetable))
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Product is already added to soup", Id));
                return;
            }

            if (vegetable.IsReadyToCook())
                Products.Add(vegetable);
            else
                Console.WriteLine(string.Format("{0, -60} - {1}", "Product is not ready to cook", Id));
        }

        public void CookFor(Mom mom, TimeEventArgs timeArgs)
        {
            Console.WriteLine("{0, -60} - {1}", "Soup CookFor", Id);
            Console.WriteLine("Soup is cooking by " + mom.Name);
            if (WaterVolume <= 0) 
            {
                Console.WriteLine(string.Format("{0, -60} - {1}", "Exiting Soup CookFor because of Water absence", Id));
                return;
            }
            foreach (Product product in Products)
                product.IsCooking = true;
            foreach (Product product in Products)
            {
                for (TimeSpan i = TimeSpan.Zero; i < timeArgs.Time; i += TimeSpan.FromSeconds(1))
                    product.BoilFor(timeArgs.Time);
            }
            foreach (Product product in Products)
                product.IsCooking = false;
        }
        public void Cook(Mom mom)
        {
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Cook", Id));
            CookFor(mom, new TimeEventArgs(Products.Max(x => x.MinBoilTime)));
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