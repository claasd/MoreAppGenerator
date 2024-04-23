namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppFoldersClient
{
    internal MoreAppFoldersClient(HttpClient client) : this("https://api.moreapp.com/api/v1.0/forms",client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}