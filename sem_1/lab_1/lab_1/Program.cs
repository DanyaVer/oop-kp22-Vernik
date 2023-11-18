using Data;
using System;
using System.Diagnostics.Tracing;

namespace lab_1
{
    public class A : IDisposable
    {
        Guid Id { get; }
        public int Number { get; set; }
        public A()
        {
            Id = Guid.NewGuid();
            //Console.WriteLine(string.Format("{0, -60} - {1}", "A public constructor", Number));
            //Console.WriteLine(string.Format("{0, -60} - {1}", "A public constructor", Id));
        }
        public A(int number)
            :this()
        {
            Number = number;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0, -60} - {1}", "A public constructor", Number));
            Console.ForegroundColor = ConsoleColor.White;
        }

        ~A()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(string.Format("{0, -60} - {1}", "A public destructor", Id));
            Console.WriteLine(string.Format("{0, -60} - {1}", "A public destructor", Number));
            Console.ForegroundColor = ConsoleColor.White;
            Dispose(false);
        }

        private bool IsDisposed { get; set; }
        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose", Id));
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose", Number));
            Console.ForegroundColor = ConsoleColor.White;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDisposing)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool)", Id));
            Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool)", Number));
            Console.ForegroundColor = ConsoleColor.White;
            // check if already disposed
            if (!IsDisposed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool) if (!isDisposed)", Id));
                Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool) if (!isDisposed)", Number));
                Console.ForegroundColor = ConsoleColor.White;
                if (isDisposing)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Format("{0, -60} - {1}", "Soup Dispose(bool) if (!isDisposed) if (isDisposing)", Id));
                    Console.ForegroundColor = ConsoleColor.White;
                    // free managed objects here 
                }

                // set the bool value to true 
                IsDisposed = true;
            }
        }
    }

    internal class Program
    {
        static void SoupCooking()
        {
            using (Soup soup = Soup.SoupInstance)
            {
                Console.WriteLine("Soup generation: " + GC.GetGeneration(soup));

                List<Product> products = new List<Product>();
                Carrot carrot = new Carrot(20);
                Product car = new Carrot(20);
                products.Add(carrot);
                Console.WriteLine(string.Format("{0:-60} ", "Carrot IsEatable: " + products[0].IsEatable));
                Console.WriteLine(string.Format("{0:-60} ", "(Carrot)Product IsEatable: "+ ((Carrot)car).IsEatable));

                Meat meat_1 = new Chicken(608);
                Pork meat_2 = new Pork(313);
                Carrot carrot_1 = new Carrot(44);
                Carrot carrot_2 = new Carrot(52);
                Product potato_1 = new Potato(87);
                Product potato_2 = new Potato(72);
                Product potato_3 = new Potato(79);
                potato_1.AddToSoup(soup);

                carrot_1.AddToSoup(soup);
                carrot_2.AddToSoup(soup);
                potato_1.AddToSoup(soup);
                potato_2.AddToSoup(soup);
                potato_3.AddToSoup(soup);

                Console.WriteLine(string.Format("{0:-60} ", "Has meat: " + soup.HasMeat()));
                Console.WriteLine(string.Format("{0:-60} ", "Has carrot: " + soup.HasCarrot()));
                Console.WriteLine(string.Format("{0:-60} ", "Has potato: " + soup.HasPotato()));

                meat_1.AddToSoup(soup);
                meat_2.AddToSoup(soup);



                soup.CookFor(TimeSpan.FromSeconds(1));
                
                Console.WriteLine("Soup generation: " + GC.GetGeneration(soup));
                soup.Dispose();
                Console.WriteLine("Soup generation: " + GC.GetGeneration(soup));

                Console.WriteLine("meat_1 Generation: " + GC.GetGeneration(meat_1));
                Console.WriteLine("GC Collect 0");
                GC.Collect(0);
                Console.WriteLine("meat_1 Generation: " + GC.GetGeneration(meat_1));
                Console.WriteLine("GC Collect 1");
                GC.Collect(1);
                Console.WriteLine("meat_1 Generation: " + GC.GetGeneration(meat_1));
                Console.WriteLine("GC Collect 2");
                GC.Collect(2);
                Console.WriteLine("meat_1 Generation: " + GC.GetGeneration(meat_1));
                
                meat_1.Dispose();
                meat_1.Dispose();
                meat_1 = null;
                GC.ReRegisterForFinalize(meat_2);
                meat_2 = null;
                Console.WriteLine("\n\nEnd of SoupCooking function.\n\n");
            }
        }
        
        /// <summary>
        /// Rewrite instance of class A each time in the cycle
        /// </summary>
        static void TestGarbageCollection()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTestGarbageCollection\n");
            Console.ForegroundColor = ConsoleColor.White;
            int n = 1;
            for (int i = 0; i < Math.Pow(10, n); i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Sleep 100");
                    Thread.Sleep(100);
                    Console.WriteLine("No Sleep");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Cycle " + i);
                Console.ForegroundColor = ConsoleColor.White;
                A a = new A(i);
                if (i % Math.Pow(10, n - 1) == 0)
                {
                    Console.WriteLine($"GC Total Memory not forced in {i / Math.Pow(10, n - 1)} is: {GC.GetTotalMemory(false)}");
                    Console.WriteLine($"GC Total Memory     forced in {i / Math.Pow(10, n - 1)} is: {GC.GetTotalMemory(true)}");
                    Console.WriteLine();
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"GC Total Memory not forced is: {GC.GetTotalMemory(false)}");
            Console.WriteLine($"GC Total Memory     forced is: {GC.GetTotalMemory(true)}");
            Console.WriteLine();
        }

        /// <summary>
        /// Create instance of class A each time in the cycle and keep it in the list
        /// </summary>
        static void TestGarbageCollection2()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTestGarbageCollection2\n");
            Console.ForegroundColor = ConsoleColor.White;
            int n = 1;
            List<A> listOfA = new List<A>();

            Console.WriteLine("List of A generation: " + GC.GetGeneration(listOfA));
            for (int i = 0; i < Math.Pow(10, n); i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Sleep 100");
                    Thread.Sleep(100);
                    Console.WriteLine("No Sleep");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Cycle " + i);
                Console.ForegroundColor = ConsoleColor.White;
                A a = new A(i);
                listOfA.Add(a);
                if (i % Math.Pow(10, n - 1) == 0)
                {
                    Console.WriteLine($"GC Total Memory not forced in {i / Math.Pow(10, n - 1)} is: {GC.GetTotalMemory(false)}");
                    Console.WriteLine($"GC Total Memory     forced in {i / Math.Pow(10, n - 1)} is: {GC.GetTotalMemory(true)}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("List of A generation: " + GC.GetGeneration(listOfA));
            listOfA = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"GC Total Memory not forced is: {GC.GetTotalMemory(false)}");
            Console.WriteLine($"GC Total Memory     forced is: {GC.GetTotalMemory(true)}");
            Console.WriteLine();
        }


        static void TestUsing()
        {
            using (Carrot carrot1 = new Carrot(45)) { }
            Meat meat = new Pork(200);
            Console.WriteLine("Meat Generation: " + GC.GetGeneration(meat));
            GC.Collect(0);
            GC.Collect(1);
            GC.Collect(2);
            Console.WriteLine("Meat Generation: " + GC.GetGeneration(meat));
            meat = new Pork(200);
            Console.WriteLine("Meat Generation: " + GC.GetGeneration(meat));
        }

        static void Main(string[] args)
        {
            TestGarbageCollection();
            TestGarbageCollection2();
            TestUsing();
            Console.ReadKey();

            Soup soup1 = Soup.SoupInstance;
            Console.WriteLine("Soup1 Generation: " + GC.GetGeneration(soup1));
            // checking if generation of a singleton instance
            // will be 1 after GC.Collect(0)
            Console.WriteLine("GC Collect 0");
            GC.Collect(0);

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\n\nTotal Memory: " + GC.GetTotalMemory(false) + "\n\n");
         
                Console.WriteLine("Main before SoupCooking\n");
                SoupCooking();
                Console.WriteLine("\nMain after SoupCooking");

                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine("GC Collect 0");
            GC.Collect(0);
            Console.WriteLine("GC Collect 1");
            GC.Collect(1);
            Console.WriteLine("GC Collect 2");
            GC.Collect(2);
            Console.WriteLine("Soup1 Generation: " + GC.GetGeneration(soup1));

            Console.ReadKey();

            Soup soup2 = Soup.SoupInstance;
            Console.WriteLine("Soup2 Generation: " + GC.GetGeneration(soup2));
            Console.WriteLine("Total Memory: " + GC.GetTotalMemory(false));

            Console.ReadKey();
        }
    }
}