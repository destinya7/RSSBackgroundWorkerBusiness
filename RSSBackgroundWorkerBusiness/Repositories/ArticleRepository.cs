using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly RSSContext _context;

        public ArticleRepository(RSSContext context)
        {
            this._context = context;
        }

        public async Task<RepositoryActionResult<Article>> Add(Article article)
        {
            try
            {
                article.DateCreated = DateTime.UtcNow;
                article.DateModified = DateTime.UtcNow;

                _context.Articles.Add(article);

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return new RepositoryActionResult<Article>(article, RepositoryActionStatus.Created);
                }

                return new RepositoryActionResult<Article>(article, RepositoryActionStatus.NothingModified);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Article>(article, RepositoryActionStatus.Error, ex);
            }
        }

        public async Task<RepositoryActionResult<Article>> Delete(int id)
        {
            try
            {
                var existingArticle = await _context.Articles.FirstOrDefaultAsync(
                    a => a.Id == id);

                if (existingArticle != null)
                {
                    _context.Articles.Remove(existingArticle);

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new RepositoryActionResult<Article>(existingArticle, RepositoryActionStatus.Deleted);
                    }

                    return new RepositoryActionResult<Article>(existingArticle, RepositoryActionStatus.NothingModified);
                }

                return new RepositoryActionResult<Article>(existingArticle, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Article>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public Article Get(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Article> GetAll()
        {
            return _context.Articles;
        }

        public Task<Article> GetByUrl(string url)
        {
            return _context.Articles.FirstOrDefaultAsync(a => a.Link == url);
        }

        public async Task<RepositoryActionResult<Article>> Update(Article article)
        {
            try
            {
                var existingArticle = await _context.Articles.FirstOrDefaultAsync(
                    a => a.Id == article.Id);

                if (existingArticle != null)
                {
                    existingArticle.DateModified = DateTime.Now;
                    existingArticle.Title = article.Title;
                    existingArticle.Description = article.Description;
                    existingArticle.Link = article.Link;

                    _context.Entry(existingArticle).State = EntityState.Modified;

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new RepositoryActionResult<Article>(article, RepositoryActionStatus.Updated);
                    }

                    return new RepositoryActionResult<Article>(article, RepositoryActionStatus.NothingModified);
                }

                return new RepositoryActionResult<Article>(article, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Article>(article, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
