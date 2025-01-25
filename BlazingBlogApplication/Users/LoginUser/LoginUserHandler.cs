using BlazingBlogApplication.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Users.LoginUser
{
    internal class LoginUserHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _authenticationService.LoginUserAsync(request.UserName, request.Password);
            
            if(success)
            {
                return Result.Ok();
            }

            return Result.Fail("Username or Password is wrong");
        }
    }
}
