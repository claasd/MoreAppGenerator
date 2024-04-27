using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public class MoreAppService
{
    private readonly RestClient _client;

    public MoreAppService(int customerId, string secret) => _client = new RestClient(customerId, secret);
    public IMoreAppBuilder Builder() => new Implementation.MoreAppBuilder(_client);
    public async Task<IFormInfo?> ExistingFormById(string id) => await FormBuilder.ExistingFormById(_client, id);
    public async Task<IFormInfo?> ExistingFormByName(string name) => await FormBuilder.ExistingFormByName(_client, name);
    public async Task<Stream> DownloadSubmissionFile(string fileId) => await Submissions.DownloadSubmissionFile(_client, fileId);
}