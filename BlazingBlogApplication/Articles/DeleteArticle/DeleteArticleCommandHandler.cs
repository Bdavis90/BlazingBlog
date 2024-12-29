namespace BlazingBlogApplication.Articles.DeleteArticle
{
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _articleRepository.DeleteArticleAsync(request.Id);
            if(deleted)
            {
                return Result.Ok();
            }

            return Result.Fail("The article does not exist.");
        }
    }
}
