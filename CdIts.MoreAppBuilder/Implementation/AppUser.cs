namespace MoreAppBuilder.Implementation;

public class AppUser : IUser
{
    public AppUser(string email, string id, bool validated)
    {
        Email = email;
        Id = id;
        Validated = validated;
    }

    public string Id { get; }
    public string Email { get; }
    public bool Validated { get; }
}