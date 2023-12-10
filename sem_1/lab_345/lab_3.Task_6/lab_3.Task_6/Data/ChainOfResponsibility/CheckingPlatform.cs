using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_6.Data.ChainOfResponsibility
{
    public class CheckingPlatform
    {
        List<Paper> papers = new List<Paper>();
        public async Task<bool> CheckStudentPaper(Teacher teacher)
        {
            if (teacher == null) 
                return false;

            List<Task> tasks = new List<Task>();
            foreach (Paper paper in papers)
            {
                tasks.Add(_ = Task.Run(async () =>
                {
                    int i = 0;
                    // if no teacher was available, start anew
                    while (!await teacher.CheckPaper(paper))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Checking {0}'s paper again ({1} time)", paper.Name, i++);
                        Console.ForegroundColor = ConsoleColor.White;
                        // waiting for a second to increase chances of succeeding
                        await Task.Delay(1000);
                    }
                }));
                
                // is used so that teachers will have time to start checking
                await Task.Delay(10);
            }

            Task.WaitAll(tasks.ToArray());

            return true;
        }

        public void DisplayResults()
        {
            foreach (Paper paper in papers)
            {
                Console.WriteLine("Student {0} got {1}", paper.Name, paper.Score);
            }
        }

        public void AddPaper(Paper paper) => papers.Add(paper);

        public void AddPapers(params Paper[] papers)
        {
            if (papers == null)
                return;
            foreach (Paper paper in papers)
                AddPaper(paper);
        }
    }
}
