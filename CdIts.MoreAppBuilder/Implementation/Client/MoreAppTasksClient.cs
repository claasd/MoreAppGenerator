namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppTasksClient
{
    internal MoreAppTasksClient(HttpClient client): this("https://api.moreapp.com", client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}