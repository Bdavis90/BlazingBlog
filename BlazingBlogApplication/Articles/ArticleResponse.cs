using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles
{
    public record struct ArticleResponse(int Id, string Title, string? Content, DateTime DatePublished, bool IsPublished, string UserName, string UserId, bool CanEdit);
}
