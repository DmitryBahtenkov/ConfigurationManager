using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Core.Helpers;
using ConfigurationManager.Framework.CQRS;
using ConfigurationManager.Framework.Exceptions;

namespace ConfigurationManager.Core.Users.Handlers;

public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, User>
{
    private readonly IContext _context;

    public UpdateUserHandler(IContext context)
    {
        _context = context;
    }


    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if(user is null || user.IsArchived)
        {
            throw new NotFoundException("Пользователь не найден");
        }

        PasswordHelper.GeneratePassword(request.Password, out var hash, out var salt);
        user.Login = request.Login;
        user.Password = hash;
        user.Salt = salt;

        var entry = _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }
}