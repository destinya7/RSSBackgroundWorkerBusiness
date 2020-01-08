using RSSBackgroundWorkerBusiness.Repository;
using RSSBackgroundWorkerBusinessWCF.Factories;
using RSSBackgroundWorkerBusinessWCF.Messages;
using RSSBackgroundWorkerBusinessWCF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusinessWCF.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repo;
        private readonly IArticleFactory _factory;

        public ArticleService(
            IArticleRepository repo,
            IArticleFactory factory
        )
        {
            this._repo = repo;
            this._factory = factory;
        }

        public async Task<ArticleMessage> AddArticle(Article article)
        {
            try
            {
                var articleEntity = _factory.CreateArticle(article);
                var result = await _repo.Add(articleEntity);

                return new ArticleMessage(
                    _factory.CreateArticle(result.Entity),
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ArticleMessage(
                    article, MessageStatus.Error, ex);
            }
        }

        public async Task<ArticleMessage> DeleteArticle(int id)
        {
            try
            {
                var result = await _repo.Delete(id);
                var message = result.Entity != null
                    ? _factory.CreateArticle(result.Entity)
                    : null;

                return new ArticleMessage(
                    message,
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ArticleMessage(
                    null, MessageStatus.Error, ex);
            }
        }

        public Article GetArticle(int id)
        {
            return _factory.CreateArticle(_repo.Get(id));
        }

        public IEnumerable<Article> GetArticles()
        {
            return _repo.GetAll().ToList()
                .Select(a => _factory.CreateArticle(a));
        }

        public async Task<ArticleMessage> UpdateArticle(Article article)
        {
            try
            {
                var articleEntity = _factory.CreateArticle(article);
                var result = await _repo.Update(articleEntity);
                var message = result.Entity != null
                    ? _factory.CreateArticle(result.Entity)
                    : null;

                return new ArticleMessage(
                    message,
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ArticleMessage(
                    article, MessageStatus.Error, ex);
            }
        }
    }
}
