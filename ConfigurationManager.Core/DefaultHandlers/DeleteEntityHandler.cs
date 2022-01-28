using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Framework.CQRS;
using ConfigurationManager.Framework.Exceptions;

namespace ConfigurationManager.Core.DefaultHandlers;

public abstract class DeleteEntityHandler<TCommand, TEntity> : ICommandHandler<TCommand, TEntity> 
    where TCommand : ICommand<TEntity> 
    where TEntity : BaseModel
{
    protected IContext Context { get; }

    protected DeleteEntityHandler(IContext context)
    {
        Context = context;
    }

    public abstract Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken);

    protected virtual async Task<TEntity> DeleteEntity<TKey>(TKey id, CancellationToken cancellationToken = default, bool safe = true)
    {
        var set = Context.Set<TEntity>();
        var entity = await set.FindAsync(id);
        if(entity is null)
        {
            throw new NotFoundException("Не найден объект");
        }

        if(safe)
        {
            entity.IsArchived = true;
        }
        else
        {
            entity = set.Remove(entity).Entity;
        }

        await Context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}