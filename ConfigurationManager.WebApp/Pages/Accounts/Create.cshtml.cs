using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConfigurationManager.WebApp.Pages.Accounts
{
    public class Create : PageModel
    {
        [BindProperty]
        public CreateUserCommand Command { get; set; } = new();

        private readonly ILogger<Create> _logger;
        private readonly IToastifyService _toastifyService;
        private readonly IMediator _mediator;

        public Create(
            ILogger<Create> logger,
            IMediator mediator,
            IToastifyService toastifyService)
        {
            _toastifyService = toastifyService;
            _mediator = mediator;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if(!ModelState.IsValid)
            {
                return;
            }

            try
            {
                await _mediator.Send<User>(Command);
                _toastifyService.Success("Успешно");
                Redirect("Users");
            }
            catch (System.Exception ex)
            {
                _toastifyService.Error(ex.Message);
            }
        }
    }
}
