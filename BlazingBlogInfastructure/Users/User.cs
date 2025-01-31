using BlazingBlogDomain.Articles;
using BlazingBlogDomain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure.Users
{
    public class User : IdentityUser, IUser
    {
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
