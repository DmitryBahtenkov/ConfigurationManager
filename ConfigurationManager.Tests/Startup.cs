using System.Reflection;
using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using ConfigurationManager.Core.Users.Handlers;
using ConfigurationManager.Framework.CQRS;
using ConfigurationManager.Tests.Db;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationManager.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<IContext, TestContext>();
        services.AddMediatR(Assembly.Load("ConfigurationManager.Tests"));
        services.AddMediatR(Assembly.Load("ConfigurationManager.Core"));
        services.AddMediatR(Assembly.Load("ConfigurationManager.Core.Contract"));
        services.AddMediatR(Assembly.Load("ConfigurationManager.Framework"));
    }
}