using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_6.Data
{
    public class Paper
    {
        public string Name { get; set; }
        public Paper(string name = "Danylo", params string[] answers)
        {
            Name = name;
            if (answers != null)
                Answers = answers.ToList();


        }

        public List<string>? Answers { get; set; }

        public double Score { get; set; }
    }
}
