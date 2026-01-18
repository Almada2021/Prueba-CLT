using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Application.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries;

public record GetAllUsersQuery() : IRequest<List<UserResponseDto>>;

