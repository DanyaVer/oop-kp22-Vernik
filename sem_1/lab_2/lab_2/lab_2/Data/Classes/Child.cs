using Data.Classes;
using Data.Classes.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Data.Classes
{
    public class Child
    {
        public string Name { get; set; }
        private Meal _preferrableMeal { get; set; }
        public Meal PreferrableMeal 
        { 
            get => _preferrableMeal; 
            set 
            { 
                Cooker.AddMeal(value);
                _preferrableMeal = value; 
            }
        }
        public Cooker Cooker { get; }
        public Child(string name, Meal meal, Cooker cooker)
        {
            Cooker = cooker;
            Name = name;
            PreferrableMeal = meal;
        }
        public Child()
            : this("Danya", new Soup(), new Cooker(new Mom("Julie")))
        { }
    }
}
