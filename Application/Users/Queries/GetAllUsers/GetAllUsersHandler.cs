using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Users.Queries;

public class GetAllUsersQueryHandler(AppDbContext context) : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
{
    private readonly AppDbContext _context = context;

    public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Users.AsNoTracking();
        // GET ALL USERS
        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
        }
        return await query
              .Select(user => new UserResponseDto
              {
                  Id = user.Id,
                  Name = user.Name,
                  Email = user.Email,
                  IsActive = user.IsActive,
              })
              .ToListAsync(cancellationToken);
    }
}