namespace BlazingBlogApplication.Articles.GetArticleByID
{
    public class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _articleRepository.GetArticleByIdAsync(request.Id);
            if(result is null)
            {
                return Result.Fail<ArticleResponse?>("The article does not exist.");
            }
            return result.Adapt<ArticleResponse>();
        }
    }
}
