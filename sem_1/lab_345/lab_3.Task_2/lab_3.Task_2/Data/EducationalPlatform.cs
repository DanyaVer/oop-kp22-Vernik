using lab_3.Task_2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_2.Data
{
    public class EducationalPlatform : IPlatform
    {
        List<Module> Modules { get; set; } = new List<Module>();

        public Module? GetModule(string Topic) => Modules.FirstOrDefault(Module => Module.Topic == Topic);

        public PlatformResponse<Models.Task> GetTasks(User user, int ModuleId)
        {
            List<Models.Task>? Result = Modules.FirstOrDefault(Module => Module.Id == ModuleId)?.Tasks;

            return new PlatformResponse<Models.Task>()
            {
                IsSuccessful = Result == null,
                Result = Result ?? new List<Models.Task>()
            };
        }

        public List<Models.Task> GetPreviousTasks(int ModuleId)
        {
            int index = Modules.FindIndex(Module => Module.Id == ModuleId);
            if (index == -1)
                throw new ArgumentException();
            List<Module> previousModules = Modules.Take(index).ToList();
            List<Models.Task> previousTasks = new List<Models.Task>();
            foreach (Module module in previousModules)
            {
                previousTasks.AddRange(module.Tasks);
            }
            return previousTasks;
        }
    }
}
