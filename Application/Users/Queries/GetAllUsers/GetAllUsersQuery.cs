using MediatR;


namespace Application.Users.Queries;

public record GetAllUsersQuery(bool? IsActive = null) : IRequest<List<UserResponseDto>>;

