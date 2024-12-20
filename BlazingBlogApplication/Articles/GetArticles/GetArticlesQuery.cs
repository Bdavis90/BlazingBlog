using BlazingBlogDomain.Articles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles.GetArticles
{
    public class GetArticlesQuery : IRequest<List<ArticleResponse>>
    {
    }
}
