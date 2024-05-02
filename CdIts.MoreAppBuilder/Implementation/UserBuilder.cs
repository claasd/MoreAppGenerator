using System.ComponentModel;
using Caffoa;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

internal class UserBuilder : IUserBuilder
{
    private readonly RestClient _client;
    private HashSet<string> _groups = new();
    private readonly string _email;
    private RestInviteUser.LanguageValue _language = RestInviteUser.LanguageValue.En;

    internal UserBuilder(RestClient client, string email)
    {
        _email = email.ToLower();
        _client = client;
    }

    public IUserBuilder InvitationLanguage(Language language)
    {
        _language = Caffoa.EnumConverter.FromString<RestInviteUser.LanguageValue>(language.Value());
        return this;
    }

    public IUserBuilder Group(IGroup group)
    {
        _groups.Add(group.Id);
        return this;
    }

    public IUserBuilder Groups(IEnumerable<IGroup> groups)
    {
        foreach (var group in groups)
            _groups.Add(group.Id);
        return this;
    }

    public async Task<IUser> BuildAsync()
    {
        var userClient = new MoreAppUsersClient(_client.HttpClient);
        var allUsers = await userClient.GetUsersAsync(_client.CustomerId);
        var user = allUsers.FirstOrDefault(u => u.EmailAddress.Equals(_email, StringComparison.OrdinalIgnoreCase));
        if (user is null)
            return await BuildInvite();
        var groupClient = new MoreAppGroupsClient(_client.HttpClient);
        foreach (var newGroup in _groups.Except(user.Groups))
            await groupClient.AddUserAsync(_client.CustomerId, newGroup, user.Id);

        foreach (var obsoleteGroup in user.Groups.Except(_groups))
            await groupClient.RemoveUserAsync(_client.CustomerId, obsoleteGroup, user.Id);
        return new AppUser(_email, user.Id, user.EmailValidated ?? false);
    }

    private async Task<AppUser> BuildInvite()
    {
        var invitesClient = new MoreAppInvitesClient(_client.HttpClient);
        var invites = await invitesClient.GetInvitesAsync(_client.CustomerId);
        var existing = invites.FirstOrDefault(i => i.EmailAddress.Equals(_email, StringComparison.OrdinalIgnoreCase));
        if (existing is null)
            return await CreateNewInvite();
        foreach (var newGroup in _groups.Except(existing.Groups))
            await invitesClient.AddGroupAsync(_client.CustomerId, newGroup, existing.Id);

        foreach (var obsoleteGroup in existing.Groups.Except(_groups))
            await invitesClient.RemoveGroupAsync(_client.CustomerId, obsoleteGroup, existing.Id);
        return new AppUser(_email, existing.Id, false);
    }

    private async Task<AppUser> CreateNewInvite()
    {
        var invitesClient = new MoreAppInvitesClient(_client.HttpClient);
        await invitesClient.InviteUserAsync(_client.CustomerId, new RestInviteUser
        {
            EmailAddress = _email,
            Language = _language,
            Groups = _groups.ToList()
        });
        var invites = await invitesClient.GetInvitesAsync(_client.CustomerId);
        var existing = invites.First(i => i.EmailAddress.Equals(_email, StringComparison.OrdinalIgnoreCase));
        return new AppUser(_email, existing.Id, false);
    }
}