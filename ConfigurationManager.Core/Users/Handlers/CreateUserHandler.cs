using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Core.Helpers;
using ConfigurationManager.Framework.CQRS;
using ConfigurationManager.Framework.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Users.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, User>
{
    private readonly IContext _context;

    public CreateUserHandler(IContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == request.Login && !x.IsArchived);
        if(existUser is not null)
        {
            throw new BusinessException("Такой пользователь уже существует");
        }

        PasswordHelper.GeneratePassword(request.Password, out var hash, out var salt);
        var entry = await _context.Users.AddAsync(new User
        {
            Login = request.Login,
            Password = hash,
            Salt = salt
        });

        await _context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }
}