namespace Application.Users.Commands;

public class CreateUserRequest
{
    /// <example>Pablo</example>
    public required string Name { get; set; }

    /// <example>pablo@gmail.com</example>
    public required string Email { get; set; }

    /// <example>password</example>
    public required string Password { get; set; }
}