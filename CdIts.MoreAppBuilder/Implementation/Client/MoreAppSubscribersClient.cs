namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppSubscribersClient
{
    internal MoreAppSubscribersClient(HttpClient client) : this("https://api.moreapp.com/api/v1.0/webhooks",client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}