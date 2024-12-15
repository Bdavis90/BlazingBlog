using BlazingBlogDomain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles
{
    public class ArticleService : IArticleService
    {
        public List<Article> GetAllArticles()
        {
            return new List<Article> {
                new Article
                {
                    Id = 1,
                    Title = "My first article",
                    Content = "This is my first article"
                },
                new Article
                {
                    Id = 2,
                    Title = "My second article",
                    Content = "This is my second article"
                }
            };
        }
    }
}
