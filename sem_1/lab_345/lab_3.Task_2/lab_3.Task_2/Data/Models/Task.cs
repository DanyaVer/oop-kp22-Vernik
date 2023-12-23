using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data.Models
{
    public class Task
    {
        private static int Count = 0;
        public Task(int ModuleId, string TaskType, string Problem, int Points, string CorrectAnswer)
        {
            Id = Count++;
            this.ModuleId = ModuleId;
            this.TaskType = TaskType;
            this.Problem = Problem;
            this.Points = Points;
            this.CorrectAnswer = CorrectAnswer;
        }

        public int Id { get; private set; }
        public int ModuleId { get; set; }
        public string TaskType { get; set; }
        public string Problem { get; set; }
        public int Points { get; set; }
        private string CorrectAnswer { get; set; }


        public TaskAnswer CheckAnswer(TaskAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException();

            if (answer.Answer == CorrectAnswer)
                answer.Score = Points;
            else if (CorrectAnswer.Contains(answer.Answer))
                answer.Score = (int)Math.Ceiling((double)Points / 2);
            else
                answer.Score = 0;

            return answer;
        }
    }
}
