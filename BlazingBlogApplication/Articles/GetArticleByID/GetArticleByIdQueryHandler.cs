using BlazingBlogDomain.Articles;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles.GetArticleByID
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleResponse?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _articleRepository.GetArticleByIdAsync(request.Id);
            if(result is null)
            {
                return null;
            }
            return result.Adapt<ArticleResponse>();
        }
    }
}
