namespace MoreAppBuilder;

public class TaskFilter
{
    public record DateFilter(DateTimeOffset? Start = null, DateTimeOffset? End = null);

    public record StringBasedFilter(string Path, string Value);
    
    public TaskStatus? Status { get; set; }
    public DateFilter? DueDate { get; set; }
    public DateFilter? CreationDate { get; set; }
    public DateFilter? PublishDate { get; set; }
    public List<string> MessageSearch { get; set; } = [];
    public List<StringBasedFilter> StringDataFilter { get; set; } = [];
}