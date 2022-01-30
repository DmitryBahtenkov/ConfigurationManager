using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Queries;
using ConfigurationManager.Core.Helpers;
using ConfigurationManager.WebApp.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConfigurationManager.WebApp.Pages.Accounts
{
    public class Login : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; } = new();
        private readonly ILogger<Login> _logger;
        private readonly IMediator _mediator;

        public Login(ILogger<Login> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            var search = new GetUsersQuery(LoginViewModel.Login);
            var result = await _mediator.Send<List<User>>(search);

            if (!result.Any())
            {
                return;
            }

            var user = result.First();
            if (PasswordHelper.ComparePassword(user, LoginViewModel.Password))
            {
                var claims = new List<Claim> 
                { 
                    new Claim(ClaimTypes.Name, user.Login) 
                };
                // создаем объект ClaimsIdentity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
        }
    }
}
