using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Queries;
using ConfigurationManager.Framework.CQRS;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Users.Handlers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<User>>
{
    private readonly IContext _context;

    public GetUsersQueryHandler(IContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<User> users = _context.Users.Where(x => !x.IsArchived);

        if(!string.IsNullOrEmpty(request.Login))
        {
            users = users.Where(x => x.Login.Contains(request.Login));
        }

        return await users.AsNoTracking().ToListAsync(); 
    }
}