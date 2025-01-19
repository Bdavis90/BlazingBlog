using BlazingBlogDomain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogDomain.Users
{
    public interface IUser
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<Article> Articles { get; set; }
    }
}
