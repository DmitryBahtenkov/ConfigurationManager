using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Core.DefaultHandlers;

namespace ConfigurationManager.Core.Users.Handlers;

public class DeleteUserHandler : DeleteEntityHandler<DeleteUserCommand, User>
{
    public DeleteUserHandler(IContext context) : base(context)
    {
    }

    public override async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await DeleteEntity(request.Id, cancellationToken);
    }
}