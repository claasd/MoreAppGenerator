namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppUsersClient
{
    internal MoreAppUsersClient(HttpClient client)  : this("https://api.moreapp.com", client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
    
}