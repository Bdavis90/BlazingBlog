using BlazingBlogApplication.Users;

namespace BlazingBlogApplication.Articles.UpdateArticle
{
    internal class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserService _userService;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
        {
            _articleRepository = articleRepository;
            _userService = userService;
        }

        public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var updatedArticle = request.Adapt<Article>();
            if(!await _userService.CurrentUserCanEditArticleAsync(updatedArticle.Id))
            {
                return Result.Fail<ArticleResponse?>("You're not allowed to edit this article! How did you get here.");
            }
            var article =  await _articleRepository.UpdateArticleAsync(updatedArticle);
            if(article is null)
            {
                return Result.Fail<ArticleResponse?>("Article does not exist.");
            }

            return article.Adapt<ArticleResponse>();
        }
    }
}
