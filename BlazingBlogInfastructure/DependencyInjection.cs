using BlazingBlogApplication.Articles;
using BlazingBlogApplication.Authentication;
using BlazingBlogDomain.Articles;
using BlazingBlogDomain.Users;
using BlazingBlogInfastructure.Authentication;
using BlazingBlogInfastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            AddAuthentication(services);

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static void AddAuthentication(IServiceCollection services)
        {
            // Work around for authentication returnUrl bug in .net 8
            services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddCascadingAuthenticationState();
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
        }
    }
}
