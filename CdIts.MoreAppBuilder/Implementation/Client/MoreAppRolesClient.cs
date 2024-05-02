namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppRolesClient
{
    public MoreAppRolesClient(HttpClient client) : this("https://api.moreapp.com", client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}