namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppInvitesClient
{
    internal MoreAppInvitesClient(HttpClient client): this("https://api.moreapp.com", client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}