using BlazingBlogDomain.Articles;
using BlazingBlogDomain.Users;

namespace BlazingBlogApplication.Articles.GetArticleByID
{
    public class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleByIdAsync(request.Id);
            if(article is null)
            {
                return Result.Fail<ArticleResponse?>("The article does not exist.");
            }

            var articleResponse = article.Adapt<ArticleResponse>();
            if (article.UserId is not null)
            {
                var author = await _userRepository.GetUserByIdAsync(article.UserId);
                articleResponse.UserName = author?.UserName ?? "Unknown";
            }
            else
            {
                articleResponse.UserName = "Unknown";
            }

            return articleResponse;
        }
    }
}
