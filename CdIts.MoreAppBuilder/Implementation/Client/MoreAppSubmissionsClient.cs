namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppSubmissionsClient
{
    internal MoreAppSubmissionsClient(HttpClient client) : this("https://api.moreapp.com",client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}