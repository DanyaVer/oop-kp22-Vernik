using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_1.Data
{
    /// <summary>
    /// Leaf component of a composite structure
    /// </summary>
    public class Student : StudentGroupAbstract
    {
        public string Name { get; set; }
        public List<double> SubjectScores { get; set; } = new List<double>();
        public double AvgScore { get => Math.Round(SubjectScores.Count != 0 ? SubjectScores.Average() : 0, 2); }

        public Student(string name)
        {
            Name = name;
        }

        public override void DisplayInfo(int indent = 0)
        {
            if (SubjectScores != null && SubjectScores.Count != 0)
                Console.WriteLine(Utils.Indent(indent) + "Student {0} has average score of {1}", Name, AvgScore);
            else
                Console.WriteLine(Utils.Indent(indent) + "Student {0} hasn't taken exams yet", Name);
        }

        public override void TakeExam(int indent = 0)
        {
            Console.WriteLine(Utils.Indent(indent) + "Student {0} takes exam", Name);
            Random random = new Random();
            double result = Math.Round(random.NextDouble() * 100, 2);
            SubjectScores.Add(result);
            Console.WriteLine(Utils.Indent(indent) + "Student {0} got {1} for the exam", Name, result);

            if (AvgScore >= 60)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Utils.Indent(indent) + "Student {0} now has average score of {1}", Name, AvgScore);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override bool IsComposite()
        {
            return false;
        }
    }
}
