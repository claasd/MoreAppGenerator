using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Webhooks;

namespace MoreAppBuilder.Implementation;

public class WebHookBuilder : IWebHookBuilder
{
    private readonly RestClient _client;
    private readonly string _name;
    private readonly string _url;
    private readonly List<string> _types = new();
    private Subscriber.StatusValue _status = Subscriber.StatusValue.ACTIVE;
    public WebHookBuilder(RestClient client, string name, string url)
    {
        _client = client;
        _name = name;
        _url = url;
    }

    public IWebHookBuilder WithType(string type)
    {
        _types.Add(type);
        return this;
    }

    public IWebHookBuilder Disabled()
    {
        _status = Subscriber.StatusValue.DISABLED;
        return this;
    }


    public async Task<IWebhook> BuildAsync()
    {
        var client = new MoreAppSubscribersClient(_client.HttpClient);
        var hooks = await client.GetWebhookSubscribersAsync(_client.CustomerId);
        var hook = hooks.FirstOrDefault(h => h.Name == _name);
        if (hook is null)
            hook = await client.CreateWebhookSubscriberAsync(_client.CustomerId, new Subscriber()
            {
                Name = _name,
                Url = _url,
                Type = _types,
                Status = _status,
                Secret = Guid.NewGuid().ToString("N"),
            });
        else if(hook.Url != _url || !hook.Type.SequenceEqual(_types) || hook.Status != _status)
            hook = await client.UpdateWebhookSubscriberAsync(_client.CustomerId, hook.Id, new Subscriber()
            {
                Name = _name,
                Url = _url,
                Type = _types,
                Secret = hook.Secret,
                Status = _status,
            });
        return new Webhook(hook.Name, hook.Url, hook.Type, hook.Secret);
    }
}

public class Webhook : IWebhook
{
    public string Name { get; }
    public string Url { get; }
    public ICollection<string> Types { get; }
    public string Secret { get; }

    internal Webhook(string name, string url, ICollection<string> types, string secret)
    {
        Name = name;
        Url = url;
        Types = types;
        Secret = secret;
    }
}