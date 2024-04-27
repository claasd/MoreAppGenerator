using MoreAppBuilder.Implementation.Client;

namespace MoreAppBuilder.Implementation;

internal class Submissions
{
    internal static async Task<Stream> DownloadSubmissionFile(RestClient client, string fileId)
    {
        var submissionClient = new MoreAppSubmissionsClient(client.HttpClient);
        fileId = fileId.Split('/').Last();
        return await submissionClient.GetFileAsync(client.CustomerId, fileId);
    }
}