using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogDomain.Articles
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllArticlesAsync();
        Task<Article?> GetArticleByIdAsync(int id);
        Task<Article> CreateArticleAsync(Article article);
        Task<Article> UpdateArticleAsync(Article article);
    }
}
