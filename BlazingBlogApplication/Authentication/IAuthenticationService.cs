using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Authentication
{
    public interface IAuthenticationService
    {
        Task<RegisterUserResponse> RegisterUserAsync(string username, string email, string password);
        Task<bool> LoginUserAsync(string username, string password);
    }
}
