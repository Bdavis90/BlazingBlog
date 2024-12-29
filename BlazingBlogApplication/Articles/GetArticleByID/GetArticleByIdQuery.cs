namespace BlazingBlogApplication.Articles.GetArticleByID
{
    public class GetArticleByIdQuery : IQuery<ArticleResponse?>
    {
        public int Id { get; set; }
    }
}
