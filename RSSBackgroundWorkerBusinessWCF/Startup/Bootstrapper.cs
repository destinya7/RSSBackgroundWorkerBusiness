using Autofac;
using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Repository;
using RSSBackgroundWorkerBusinessWCF.Factories;
using RSSBackgroundWorkerBusinessWCF.Services;

namespace RSSBackgroundWorkerBusinessWCF.Startup
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RSSContext>().AsSelf();
            builder.RegisterType<ChannelRepository>()
                .As<IChannelRepository>();

            builder.RegisterType<ChannelFactory>()
                .As<IChannelFactory>();
            builder.RegisterType<ArticleFactory>()
                .As<IArticleFactory>();

            builder.RegisterType<ChannelService>();
            builder.RegisterType<ArticleService>();

            return builder.Build();
        }
    }
}