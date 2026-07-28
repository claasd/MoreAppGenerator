namespace MoreAppBuilder;

public interface IMoreAppTaskService
{
    int ReadPageSize { get; set; }
    Task<List<MoreAppTask>> GetTasks(int page = 0, TaskFilter? filter = null);
    Task<MoreAppTask> CreateTask(MoreAppTaskData task);
    Task DeleteTask(MoreAppTask task);
}