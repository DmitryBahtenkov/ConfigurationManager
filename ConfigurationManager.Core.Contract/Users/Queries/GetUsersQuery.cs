using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Users.Queries;

public record GetUsersQuery(string Login) : IQuery<List<User>>;