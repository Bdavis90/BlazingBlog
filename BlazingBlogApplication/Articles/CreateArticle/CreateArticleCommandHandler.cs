


namespace BlazingBlogApplication.Articles.CreateArticle
{
    public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, ArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Result<ArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var newArticle = request.Adapt<Article>();
            var article = await _articleRepository.CreateArticleAsync(newArticle);
            return article.Adapt<ArticleResponse>();
        }

 
    }
}
