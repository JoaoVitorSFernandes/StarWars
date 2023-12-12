namespace StarWars.Models;

public sealed class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Patent { get; set; }

    public IList<Role> Roles { get; set; }
    public IList<MissionLog> MissionLogs { get; set; }
    public IList<Starship> Starships { get; set; }

    public User(string name, string email, string patent)
    {
        Name = name;
        Email = email;
        Patent = patent;
    }
}