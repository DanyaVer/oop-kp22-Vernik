using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_3.Data
{
    public class Page
    {
        public Page(string pageContent)
        {
            Content = new StringBuilder(pageContent);
        }
        public StringBuilder Content { get; set; }

        public Page Copy()
        {
            return (Page)MemberwiseClone();
        }
    }
}
