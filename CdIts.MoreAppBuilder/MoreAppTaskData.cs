using MoreAppBuilder.DefaultFormObjects;

namespace MoreAppBuilder;

public class MoreAppTaskData(string[] recipients, string message, object data) {
    public string[] Recipients { get; set; } = recipients;
    public string Message { get; set; } = message;
    public object Data { get; set; } = data;
    public DateTimeOffset? DueDate { get; set; }
    public DateTimeOffset? PublishDate { get; set; }
    public MoreAppLocation? Location { get; set; }
}