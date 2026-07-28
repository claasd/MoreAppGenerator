using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

public class MoreAppTaskService(RestClient client, IFormInfo form) : IMoreAppTaskService
{
    public int ReadPageSize { get; set; } = 100;
    private readonly MoreAppTasksClient _tasksClient = new(client.HttpClient);

    public async Task<List<MoreAppTask>> GetTasks(int page = 0, TaskFilter? filter = null)
    {
        var tasks = await _tasksClient.FilterTasksAsync(client.CustomerId, form.Id, page, CreateFilter(filter));
        return tasks.Elements.Select(AsTask).ToList();
    }

    private SimpleFilter CreateFilter(TaskFilter? filter)
    {
        var result = new SimpleFilter
        {
            PageSize = ReadPageSize
        };
        if (filter?.Status != null)
        {
            result.Query.Add(new FilterQuery
            {
                Path = "status",
                Value = AsStatus(filter.Status.Value),
                Type = "string"
            });
        }

        foreach (var msgFilter in filter?.MessageSearch ?? [])
        {
            result.Query.Add(new FilterQuery
            {
                Path = "message",
                Value = msgFilter,
                Type = "string"
            });
        }
        foreach (var contentFilter in filter?.StringDataFilter ?? [])
        {
            var path = contentFilter.Path.StartsWith("data.") ? contentFilter.Path : "data." + contentFilter.Path;
            result.Query.Add(new FilterQuery
            {
                Path = path,
                Value = contentFilter.Value,
                Type = "string"
            });
        }
        AddDateFilter(result, filter?.DueDate, "informationDate");
        AddDateFilter(result, filter?.PublishDate, "publishDate");
        AddDateFilter(result, filter?.CreationDate, "creationDate");
        return result;
    }

    private void AddDateFilter(SimpleFilter result, TaskFilter.DateFilter? dateFilter, string field)
    {
        if (dateFilter?.Start != null || dateFilter?.End != null)
        {
            result.Query.Add(new FilterQuery
            {
                Path = $"dates.{field}",
                Value = new
                {
                    start = dateFilter.Start?.ToUnixTimeMilliseconds(),
                    end = dateFilter.End?.ToUnixTimeMilliseconds(),
                },
                Type = "date"
            });
        }
    }

    public async Task<MoreAppTask> CreateTask(MoreAppTaskData task)
    {
        var request = new TaskCreateRequest
        {
            Data = task.Data,
            Recipients = task.Recipients.ToArray(),
            Message = task.Message,
            InformationDate = task.DueDate,
            PublishInfo = new TaskPublishInfo
            {
                Type = task.PublishDate is null
                    ? TaskPublishInfo.TypeValue.IMMEDIATE
                    : TaskPublishInfo.TypeValue.ABSOLUTE,
                Value = task.PublishDate?.ToUnixTimeMilliseconds()
            }
        };
        var restTask = await _tasksClient.CreateTaskAsync(client.CustomerId, form.Id, request);
        return AsTask(restTask);
    }

    public async Task DeleteTask(MoreAppTask task)
    {
        await _tasksClient.DeleteTaskAsync(client.CustomerId, task.FormId, task.Id);
    }

    private static MoreAppTask AsTask(RestTask task) =>
        new(task.Id, task.FormId, AsStatus(task.Status),
            new MoreAppTaskData(task.Users.ToArray(), task.Message, task.Data)
            {
                DueDate = task.Dates?.InformationDate,
                PublishDate = task.Dates?.PublishDate,
                Location = task.Location
            });

    private RestTask.StatusValue AsStatus(TaskStatus status)
    {
        return status switch
        {
            TaskStatus.InProgress => RestTask.StatusValue.IN_PROGRESS,
            TaskStatus.Completed => RestTask.StatusValue.COMPLETED,
            TaskStatus.Revoked => RestTask.StatusValue.REVOKED,
            TaskStatus.Declined => RestTask.StatusValue.DECLINED,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }

    private static TaskStatus AsStatus(RestTask.StatusValue? taskStatus) => taskStatus switch
    {
        RestTask.StatusValue.IN_PROGRESS => TaskStatus.InProgress,
        RestTask.StatusValue.COMPLETED => TaskStatus.Completed,
        RestTask.StatusValue.REVOKED => TaskStatus.Revoked,
        RestTask.StatusValue.DECLINED => TaskStatus.Declined,
        _ => TaskStatus.InProgress
    };
}