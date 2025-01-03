﻿using BlazingBlogDomain.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogInfastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;   
        }
        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            return article;


        }

        public async Task<Article?> UpdateArticleAsync(Article article)
        {
            var articleToUpdate = await GetArticleByIdAsync(article.Id);

            if(articleToUpdate is null)
            {
                return null;
            }

            articleToUpdate.Title = article.Title;
            articleToUpdate.Content = article.Content;
            articleToUpdate.DatePublished = article.DatePublished;
            articleToUpdate.IsPublished = article.IsPublished;
            articleToUpdate.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            return articleToUpdate;

        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await GetArticleByIdAsync(id);
            if(article is not null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
