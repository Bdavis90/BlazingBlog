using BlazingBlogDomain.Articles;
using BlazingBlogInfastructure.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlogInfastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Article> Articles { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }


    }
}
