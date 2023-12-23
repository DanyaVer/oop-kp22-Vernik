using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data.Models
{
    public class TaskAnswer
    {
        public int UserId { get; private set; }
        public int ModuleId { get; private set; }
        public int TaskId { get; private set; }
        public string Answer { get; private set; }
        public int Score { get; set; }

        public TaskAnswer(int UserId, int ModuleId, int TaskId, string Answer)
        {
            this.UserId = UserId;
            this.ModuleId = ModuleId;
            this.TaskId = TaskId;
            this.Answer = Answer;
        }
    }
}
