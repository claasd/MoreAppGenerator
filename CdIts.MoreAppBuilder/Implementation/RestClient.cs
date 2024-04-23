namespace MoreAppBuilder.Implementation;

public class RestClient
{
    public RestClient(int customerId, string secret)
    {
        CustomerId = customerId;
        HttpClient = new HttpClient();
        HttpClient.DefaultRequestHeaders.Add("X-Api-Key", secret);
    }

    internal int CustomerId { get; }
    internal HttpClient HttpClient { get; }
}