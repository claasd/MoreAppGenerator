using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public class MoreAppService(int customerId, string secret, IMoreAppCaching? caching = null)
{
    public static ILogger Logger { get; set; } = NullLogger.Instance;
    private readonly RestClient _client = new(customerId, secret);
    private readonly IMoreAppCaching _caching = caching ?? new DummyCaching();
    public IMoreAppBuilder Builder() => new Implementation.MoreAppBuilder(_client, _caching);
    public async Task<IFormInfo?> ExistingFormById(string id) => await FormBuilder.ExistingFormById(_client, id);
    public async Task<IFormInfo?> ExistingFormByName(string name) => await FormBuilder.ExistingFormByName(_client, name);
    public async Task<Stream> DownloadSubmissionFile(string fileId) => await Submissions.DownloadSubmissionFile(_client, fileId);
    public async Task<MoreAppReadInfo> ReverseAsync(string id, string versionId, bool useLangFile, string lang = "en") => await FormBuilder.ReadAsync(_client, id, versionId, useLangFile, lang);

    public Task<IDataSource> ExistingDataSource(string name, bool allowUseCache = true) => DataSource.LoadAsync(_client, name, _caching, allowUseCache);
    public Task<IGroup> ExistingGroup(string name, bool allowUseCache = true) => GroupBuilder.LoadAsync(_client, name, _caching, allowUseCache);
    public Task<IGroup> ExistingGroupById(string id, bool allowUseCache = true) => GroupBuilder.LoadByIdAsync(_client, id, _caching, allowUseCache);
}