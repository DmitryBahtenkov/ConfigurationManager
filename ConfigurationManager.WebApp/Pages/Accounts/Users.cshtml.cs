using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Contract.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConfigurationManager.WebApp.Pages.Accounts
{
    public class Users : PageModel
    {
        private readonly ILogger<Users> _logger;
		private readonly IMediator _mediator;

        public List<User> UsersList { get; set; }

		public Users(
			ILogger<Users> logger,
			IMediator mediator)
        {
			_mediator = mediator;
            _logger = logger;
        }

        public async Task OnGet()
        {
            var query = new GetUsersQuery(string.Empty);
            UsersList = await _mediator.Send<List<User>>(query);
        }
    }
}
