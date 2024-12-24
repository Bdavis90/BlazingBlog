using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<ArticleResponse?>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime DatePublished { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
    }
}
