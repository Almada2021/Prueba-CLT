using MediatR;


namespace Application.Users.Queries;

public record GetAllUsersQuery() : IRequest<List<UserResponseDto>>;

