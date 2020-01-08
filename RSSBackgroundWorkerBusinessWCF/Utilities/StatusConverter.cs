using RSSBackgroundWorkerBusiness.Repository;
using RSSBackgroundWorkerBusinessWCF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSBackgroundWorkerBusinessWCF.Utilities
{
    public class StatusConverter
    {
        public static MessageStatus ConvertToMessageStatus(RepositoryActionStatus status)
        {
            switch (status)
            {
                case RepositoryActionStatus.Created:
                    return MessageStatus.Created;
                case RepositoryActionStatus.Updated:
                    return MessageStatus.Updated;
                case RepositoryActionStatus.Deleted:
                    return MessageStatus.Deleted;
                case RepositoryActionStatus.Error:
                    return MessageStatus.Error;
                case RepositoryActionStatus.NothingModified:
                    return MessageStatus.NothingModified;
                case RepositoryActionStatus.NotFound:
                    return MessageStatus.NotFound;
                default:
                    return MessageStatus.NothingModified;
            }
        }
    }
}