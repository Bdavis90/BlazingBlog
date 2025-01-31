using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Users
{
    public interface IUserService
    {

        Task<string> GetCurrentUserIdAsync();
        Task<bool> IsCurrentUserInRoleAsync(string role);
        Task<bool> CurrentUserCanCreateArtilcesAsync();
        Task<bool> CurrentUserCanEditArticleAsync(int articleId);
    }
}
