using Data.Classes.Args;
using Data.Classes.Meals;
using Data.Classes.Products;
using Data.Interfaces;
using lab_2.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class Cooker
    {
        List<Meal> Meals { get; set; } = new List<Meal>();
        public int Power { get; set; }
        Mom Mom;
        public Cooker(Mom mom) 
        {
            Mom = mom;
        }

        public void AddMeal(Meal meal) 
        { 
            if (!Meals.Exists(x => x == meal))
            {
                Meals.Add(meal);
                Mom.MomCookingEvent += new CookingHandle(meal.CookFor);


                Mom.MomCookingEvent += delegate (Mom mom, TimeEventArgs timeArgs)
                    {
                        if (meal is not Soup)
                            throw new NotImplementedException();

                        Soup soup = (Soup)meal;
                        Console.WriteLine("{0, -60} - {1}", "Soup CookFor");
                        Console.WriteLine("Soup is cooking by " + mom.Name);
                        if (soup.WaterVolume <= 0)
                        {
                            Console.WriteLine(string.Format("{0, -60} - {1}", "Exiting Soup CookFor because of Water absence"));
                            return;
                        }
                        foreach (Product product in ((ISoup)soup).GetItemsFromProducts<Product>())
                            product.IsCooking = true;
                        foreach (Product product in ((ISoup)soup).GetItemsFromProducts<Product>())
                        {
                            for (TimeSpan i = TimeSpan.Zero; i < timeArgs.Time; i += TimeSpan.FromSeconds(1))
                                product.BoilFor(timeArgs.Time);
                        }
                        foreach (Product product in ((ISoup)soup).GetItemsFromProducts<Product>())
                            product.IsCooking = false;
                    };

            }
            else
                Console.WriteLine("Already added that meal");
        }
    }
}
