using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Users.Handlers;

public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, User>
{
    public Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}