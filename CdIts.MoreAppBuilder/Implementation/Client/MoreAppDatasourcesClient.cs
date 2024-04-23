namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppDatasourcesClient
{
    internal MoreAppDatasourcesClient(HttpClient client) : this("https://api.moreapp.com",client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}