namespace MinimalAPIs.Models;

public class User
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public string? Email { get; init; }
    public string? Address { get; init; }
}
