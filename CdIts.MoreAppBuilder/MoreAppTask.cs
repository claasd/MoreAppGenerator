namespace MoreAppBuilder;

public class MoreAppTask
{
    internal MoreAppTask(string id, string formId, TaskStatus status, MoreAppTaskData data)
    {
        Id = id;
        FormId = formId;
        Data = data;
        Status = status;
    }

    public string Id { get;  }
    public TaskStatus Status { get;  }
    public string FormId { get; }
    public MoreAppTaskData Data { get; }
}