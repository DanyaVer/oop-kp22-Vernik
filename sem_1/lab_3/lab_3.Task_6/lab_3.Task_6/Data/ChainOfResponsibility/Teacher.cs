using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_6.Data.ChainOfResponsibility
{
    public class Teacher : IChecker
    {
        public string Name { get; set; }

        public Teacher(string name = "Julia") => Name = name;

        private IChecker? _nextChecker;
        private bool IsCheckingWork { get; set; }

        /// <summary>
        /// Passes paper if a currentChecker is not available
        /// </summary>
        /// <param name="studentPaper">paper to check</param>
        /// <returns>True if the paper was checked</returns>
        public async Task<bool> CheckPaper(Paper studentPaper)
        {
            if (!IsCheckingWork)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Teacher {0} is checking {1}'s paper", Name, studentPaper.Name);
                Console.ForegroundColor = ConsoleColor.White;
                
                await Check(studentPaper);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher {0} checked {1}'s paper", Name, studentPaper.Name);
                Console.ForegroundColor = ConsoleColor.White;
                
                return true;
            }
            else
            {
                // taking into account that there might be no next checker
                if (_nextChecker != null)
                    return await _nextChecker.CheckPaper(studentPaper);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No teacher checked {0}'s paper", studentPaper.Name);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        private async Task Check(Paper paper)
        {
            IsCheckingWork = true;
            Task checkingTask = Task.Delay(5000);
            if (paper.Answers == null || paper.Answers.Count == 0)
                paper.Score = 0;
            else
            {
                Random random = new Random();
                foreach (string answer in paper.Answers)
                {
                    if (random.NextDouble() < 0.5)
                        paper.Score++;
                }
            }
            await checkingTask;
            IsCheckingWork = false;
        }

        public IChecker SetNext(IChecker checker)
        {
            _nextChecker = checker;
            
            // to add teachers in a convenient way:
            // teacher1.SetNext(teacher2).SetNext(teacher3);
            return checker;
        }

        public void DisplayChain()
        {
            bool isNext = _nextChecker != null;
            Console.Write("Teacher {0} {1}", Name, isNext ? "-> " : "");
            
            if (isNext)
                _nextChecker?.DisplayChain();
            else
                Console.WriteLine();
        }
    }
}
