using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Articles.GetArticleByIdForEditing
{
    public class GetArticleByIdForEditingQuery : IQuery<ArticleResponse?>
    {
        public int Id { get; set; }
    }
}
