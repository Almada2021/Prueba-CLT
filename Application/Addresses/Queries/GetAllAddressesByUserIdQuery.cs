using Application.Addresses.Common;
using MediatR;

namespace Application.Addresses.Queries;

public record GetAllAddressesByUserIdQuery(int UserId) : IRequest<List<AdressResponseDto>>;