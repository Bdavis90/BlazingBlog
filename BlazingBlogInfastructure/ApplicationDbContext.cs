using BlazingBlogDomain.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Article> Articles { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }


    }
}
