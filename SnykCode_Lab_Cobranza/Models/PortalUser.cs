namespace SnykCodeLab.Models;

public sealed class PortalUser
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "Collector";
    public int CustomerId { get; set; }
    public bool Enabled { get; set; } = true;
}
