using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Users.Queries;

public class GetAllUsersQueryHandler(AppDbContext context) : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
{
    private readonly AppDbContext _context = context;

    public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // GET ALL USERS
        return await _context.Users
              .AsNoTracking()
              .Select(user => new UserResponseDto
              {
                  Id = user.Id,
                  Name = user.Name,
                  Email = user.Email,
                  IsActive = user.IsActive,
              })
              .ToListAsync(cancellationToken); //
    }
}