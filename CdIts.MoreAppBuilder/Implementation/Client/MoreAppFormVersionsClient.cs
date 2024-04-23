namespace MoreAppBuilder.Implementation.Client;

public partial class MoreAppFormVersionsClient
{
    internal MoreAppFormVersionsClient(HttpClient client) : this("https://api.moreapp.com/api/v1.0/forms",client,
        jsonParser: new JsonParser(), jsonSerializer: new CustomJsonSerializer())
    {
    }
}