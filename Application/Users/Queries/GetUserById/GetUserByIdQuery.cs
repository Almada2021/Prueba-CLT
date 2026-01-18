using MediatR;

namespace Application.Users.Queries;

public record GetUserByIdQuery(int Id) : IRequest<UserResponseDto?>;
