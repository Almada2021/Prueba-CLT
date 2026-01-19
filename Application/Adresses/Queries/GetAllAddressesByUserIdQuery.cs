using Application.Adresses.Common;
using MediatR;

namespace Application.Adresses.Queries;

public record GetAllAddressesByUserIdQuery(int UserId) : IRequest<List<AdressResponseDto>>;