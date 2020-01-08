using RSSBackgroundWorkerBusinessWCF.Messages;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusinessWCF.Services
{
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        IEnumerable<Article> GetArticles();

        [OperationContract]
        Article GetArticle(int id);

        [OperationContract]
        Task<ArticleMessage> AddArticle(Article article);

        [OperationContract]
        Task<ArticleMessage> UpdateArticle(Article article);

        [OperationContract]
        Task<ArticleMessage> DeleteArticle(int id);
    }
}
