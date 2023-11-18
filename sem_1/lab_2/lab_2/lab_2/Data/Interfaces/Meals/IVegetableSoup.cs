using Data;
using Data.Classes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IVegetableSoup : ISoup
    {
        // Because there should be no Meat. Only vegetables
        public List<T> GetItemsFromProducts<T>() where T : Vegetable;
        public void AddProduct(Vegetable vegetable);
    }
}
