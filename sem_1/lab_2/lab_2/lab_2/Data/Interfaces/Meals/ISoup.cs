using Data;
using Data.Classes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISoup : IMeal
    {
        // WHY IT SHOWS ERROR THAT SET MUST BE PUBLIC IN THE SOUP CLASS EVEN THOUGH IT'S PROTECTED ???
        //protected List<Product> Products { get; set; }
        public double WaterVolume { get; }

        public List<T> GetItemsFromProducts<T>() where T : Product;
        public void AddWater(double waterVolume);
        
        public void AddProduct(Product product);
        public bool HasPotato();
        public bool HasCarrot();
    }
}
