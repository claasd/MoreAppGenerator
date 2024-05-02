namespace MoreAppBuilder;

public interface IUserBuilder
{
    IUserBuilder InvitationLanguage(Language language);
    IUserBuilder Group(IGroup group);
    IUserBuilder Groups(IEnumerable<IGroup> groups);
    Task<IUser> BuildAsync();
    
}
public interface IUser
{
    string Id { get; }
    string Email { get; }
    bool Validated { get; }
}
