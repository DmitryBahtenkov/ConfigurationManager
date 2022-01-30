using System.Reflection;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Db;
using ConfigurationManager.WebApp.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication("Cookies");
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/accounts/login");

builder.Services.AddMediatR(Assembly.Load("ConfigurationManager.Core"));
builder.Services.AddMediatR(Assembly.Load("ConfigurationManager.Core.Contract"));
builder.Services.AddMediatR(Assembly.Load("ConfigurationManager.Framework"));
builder.Services.AddMediatR(Assembly.Load("ConfigurationManager.WebApp"));
builder.Services.AddDbContext<IContext, DatabaseContext>();
builder.Services.AddToastify(config => 
    { 
        config.DurationInSeconds = 10;
        config.Position = Position.Right; 
        config.Gravity = Gravity.Top; 
    });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseCookiePolicy();

app.Run();
