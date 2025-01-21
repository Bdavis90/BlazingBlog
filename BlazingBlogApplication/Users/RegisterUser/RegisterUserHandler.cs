using BlazingBlogApplication.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Users.RegisterUser
{
    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.RegisterUserAsync(request.UserName, request.UserEmail, request.Password);

            if (response.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail($"{string.Join(", ", response.Errors)}");
        }
    }
}
