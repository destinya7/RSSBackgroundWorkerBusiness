
namespace RSSBackgroundWorkerBusinessWCF.Factories
{
    public interface IChannelFactory
    {
        Messages.Channel CreateChannel(RSSBackgroundWorkerBusiness.Models.Channel channel);
        RSSBackgroundWorkerBusiness.Models.Channel CreateChannel(Messages.Channel channel);
    }
}