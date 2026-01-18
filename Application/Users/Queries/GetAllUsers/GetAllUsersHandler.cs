using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Users.Queries;

public class GetAllUsersQueryHandler(AppDbContext context) : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
{
    private readonly AppDbContext _context = context;

    public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // Delete user
        List<User> users = await _context.Users.ToListAsync();
        return users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive,
        }).ToList();
    }
}