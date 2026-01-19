namespace Application.Users.Commands;


// Data Transfer Object para eliminar el User
public record DeleteUserRequest(
    /// <example>1</example>
    int Id
);