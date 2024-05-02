namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppGroupsClient
{
    internal MoreAppGroupsClient(HttpClient client) : this("https://api.moreapp.com", client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}