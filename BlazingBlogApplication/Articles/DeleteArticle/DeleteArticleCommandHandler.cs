using BlazingBlogApplication.Users;
using System.Runtime.CompilerServices;

namespace BlazingBlogApplication.Articles.DeleteArticle
{
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserService _userService;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
        {
            _articleRepository = articleRepository;
            _userService = userService;
        }

        public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            if(!await _userService.CurrentUserCanEditArticleAsync(request.Id))
            {
                return Result.Fail<ArticleResponse?>("You're not allowed to delete this article! How did you get here.");
            }
            var deleted = await _articleRepository.DeleteArticleAsync(request.Id);
            if(deleted)
            {
                return Result.Ok();
            }

            return Result.Fail("The article does not exist.");
        }
    }
}
