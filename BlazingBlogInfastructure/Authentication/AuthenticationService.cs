using BlazingBlogApplication.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded;
        }

        public async Task<RegisterUserResponse> RegisterUserAsync(string username, string email, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole("Writer"));
                await _userManager.AddToRoleAsync(user, "Writer");
            }



            var response = new RegisterUserResponse
            {
                Errors = result.Errors.Select(x => x.Description).ToList(),
                Succeeded = result.Succeeded
            };

            return response;
        }
    }
}
