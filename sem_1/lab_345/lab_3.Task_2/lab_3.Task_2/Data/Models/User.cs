using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data.Models
{
    public class User
    {
        private static int Count = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<TaskAnswer> Results { get; set; }

    }
}
