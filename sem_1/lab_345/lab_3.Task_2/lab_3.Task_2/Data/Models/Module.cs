using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data.Models
{
    public class Module
    {
        private static int Count = 0;
        public int Id { get; private set; }
        public string Topic { get; set; }
        public List<Task> Tasks { get; private set; }

        public Module(string topic)
        {
            Id = Count++;
            Topic = topic;
            Tasks = new List<Task>();
        }

        public void AddTask(string TaskType, string Problem, int Points, string CorrectAnswer)
        {
            Tasks.Add(new Task(
                Id,
                TaskType,
                Problem,
                Points,
                CorrectAnswer
            ));
        }

    }
}
