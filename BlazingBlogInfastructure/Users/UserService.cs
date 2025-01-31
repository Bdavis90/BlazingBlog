using BlazingBlogApplication.Exceptions;
using BlazingBlogApplication.Users;
using BlazingBlogDomain.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IArticleRepository _articleRepository;

        public UserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IArticleRepository articleRepository)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _articleRepository = articleRepository;
        }
        public async Task<bool> CurrentUserCanCreateArtilcesAsync()
        {
            var user = await GetCurrentUserAsync();
            if(user == null)
            {
                throw new UserNotAuthorizedException();
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            var isWriter = await _userManager.IsInRoleAsync(user, "Writer");

            var result = isAdmin || isWriter;

            return result;
        }

        public async Task<bool> CurrentUserCanEditArticleAsync(int articleId)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                throw new UserNotAuthorizedException();
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            var isWriter = await _userManager.IsInRoleAsync(user, "Writer");

            var article = await _articleRepository.GetArticleByIdAsync(articleId);
            if(article == null)
            {
                return false;
            }

            var result = isAdmin || (isWriter && user.Id == article.UserId);

            return result;
        }

        public async Task<string> GetCurrentUserIdAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                throw new UserNotAuthorizedException();
            }

            return user.Id;
        }

        public async Task<bool> IsCurrentUserInRoleAsync(string role)
        {
            var user = await GetCurrentUserAsync();

            bool result = false;
            if(user is not null)
            {
                result = await _userManager.IsInRoleAsync(user, role);
            }

            return result;
        }

        private async Task<User?> GetCurrentUserAsync()
        {
            var httpContext = _contextAccessor.HttpContext;
            if (httpContext is null || httpContext.User is null)
            {
                return null;
            }

            var user = await _userManager.GetUserAsync(httpContext.User);
            return user;
        }
    }
}
