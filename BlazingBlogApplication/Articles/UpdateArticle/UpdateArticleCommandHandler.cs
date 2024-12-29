namespace BlazingBlogApplication.Articles.UpdateArticle
{
    internal class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var updatedArticle = request.Adapt<Article>();
            var article =  await _articleRepository.UpdateArticleAsync(updatedArticle);
            if(article is null)
            {
                return Result.Fail<ArticleResponse?>("Article does not exist.");
            }

            return article.Adapt<ArticleResponse>();
        }
    }
}
