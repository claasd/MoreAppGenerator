namespace MoreAppBuilder;

public interface IWebHookBuilder
{
    IWebHookBuilder WithType(string type);
    IWebHookBuilder Disabled();
    Task<IWebhook> BuildAsync();
}

public interface IWebhook
{
    string Name { get; }
    string Url { get; }
    ICollection<string> Types { get; }
    string Secret { get; }
}