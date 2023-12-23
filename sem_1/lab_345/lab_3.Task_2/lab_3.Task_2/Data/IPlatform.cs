using lab_3.Task_2.Data.Models;

namespace lab_3.Task_2.Data
{
    public interface IPlatform
    {
        PlatformResponse<Models.Task> GetTasks(User user, int ModuleId);
    }
}
