using RSSBackgroundWorkerBusinessWCF.Messages;

namespace RSSBackgroundWorkerBusinessWCF.Factories
{
    public class ArticleFactory : IArticleFactory
    {
        public RSSBackgroundWorkerBusiness.Models.Article CreateArticle(Article article)
        {
            return new RSSBackgroundWorkerBusiness.Models.Article
            {
                Title = article.Title,
                Description = article.Description,
                Link = article.Link,
                PubDate = article.PubDate,
                ChannelId = article.ChannelId
            };
        }

        public Article CreateArticle(RSSBackgroundWorkerBusiness.Models.Article article)
        {
            return new Article
            {
                Title = article.Title,
                Description = article.Description,
                Link = article.Link,
                PubDate = article.PubDate,
                ChannelId = article.ChannelId
            };
        }
    }
}