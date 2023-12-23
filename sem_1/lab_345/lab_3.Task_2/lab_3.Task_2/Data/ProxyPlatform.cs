using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Task_2.Data.Models;

namespace lab_3.Task_2.Data
{
    public class ProxyPlatform : IPlatform
    {
        EducationalPlatform EducationalPlatform { get; set; }

        public ProxyPlatform(EducationalPlatform educationalPlatform)
        {
            EducationalPlatform = educationalPlatform;
        }

        public PlatformResponse<Models.Task> GetTasks(User user, int ModuleId)
        {
            if (CheckAccess(user, ModuleId))
            {
                LogAccess(user);
                
                return EducationalPlatform.GetTasks(user, ModuleId);
            }

            return new PlatformResponse<Models.Task>() { IsSuccessful = false };
        }

        public bool CheckAccess(User user, int ModuleId)
        {
            List<Models.Task> tasks = EducationalPlatform.GetPreviousTasks(ModuleId);
            foreach (Models.Task task in tasks)
            {
                TaskAnswer? result = user.Results.FirstOrDefault(x => x.TaskId == task.Id);
                if (result == null)
                    return false;
                if (result.Score <= 0)
                    return false;
            }

            return true;
        }

        public void LogAccess(User user)
        {
            Console.WriteLine("ProxyPlatform: Logging the time of user {0} - {1} - {2} request.", user.Id, user.Name, user.Email);
        }
    }
}
