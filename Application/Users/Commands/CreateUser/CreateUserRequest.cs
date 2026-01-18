namespace Application.Users.Commands;

// Como isActive por defecto es true, no se incluye en el request 

// Data Transfer Object de user o Usuario
public record CreateUserRequest(
    string Name,
    string Email,
    string Password

);