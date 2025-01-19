using BlazingBlogDomain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogDomain.Articles
{
    public class Article : Entity
    {
        public string? UserId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime DatePublished { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
    }
}
