
namespace RSSBackgroundWorkerBusinessWCF.Factories
{
    public interface IArticleFactory
    {
        RSSBackgroundWorkerBusiness.Models.Article CreateArticle(Messages.Article article);
        Messages.Article CreateArticle(RSSBackgroundWorkerBusiness.Models.Article article);
    }
}