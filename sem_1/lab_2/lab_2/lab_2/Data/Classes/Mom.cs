using Data.Classes.Args;
using Data.Classes.Exceptions;
using Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Data.Classes
{
    public delegate void CookingHandle(Mom mom, TimeEventArgs args);
    public class Mom
    {
        public event CookingHandle MomCookingEvent;


        public string Name { get; set; }
        public Mom(string name)
        {
            Name = name;
        }

        public void Cook()
        {
            TimeEventArgs timeArgs = new TimeEventArgs();
            try
            {
                Console.Write("Enter available time to cook \nin format numbers split by ':'");
                timeArgs = new TimeEventArgs(Console.ReadLine().GetTime());
            }
            catch (Exception ex) when (ex is TimeFormatException || ex is ArgumentNullException)
            {
                // can be commented so as not to stop the program
                throw;
            }

            Console.WriteLine("Mom {0} is Cooking...\n", this.Name);
            if (MomCookingEvent != null)
                MomCookingEvent(this, timeArgs);
        }

    }
}
