using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Framework.Exceptions;
using MediatR;
using Xunit;

namespace ConfigurationManager.Tests.Users;

public class UserTests
{
    private readonly IMediator _mediator;

    public UserTests(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Fact]
    public async Task CreateValidUserTest()
    {
        var command = new CreateUserCommand
        {
            Login = "aa@a.a",
            Password = "1234",
        };

        var result = await _mediator.Send<User>(command);

        Assert.NotEqual(0, result.Id);
        Assert.NotEmpty(result.Salt);
        Assert.NotEmpty(result.Password);
    }

    [Fact]
    public async Task CreateDuplicateUserTest()
    {
        var command = new CreateUserCommand
        {
            Login = UsersTestData.ExistUserDocument.Login,
            Password = "1234",
        };

        var ex = await Assert.ThrowsAsync<BusinessException>(async () => await _mediator.Send<User>(command));

        Assert.NotEmpty(ex.Message);
    }

    [Fact]
    public async Task SafeDeleteUserTest()
    {
        var command = new DeleteUserCommand(UsersTestData.DeletionUserDocument.Id);

        var result = await _mediator.Send<User>(command);

        Assert.NotNull(result);
        Assert.True(result.IsArchived);
    }
}