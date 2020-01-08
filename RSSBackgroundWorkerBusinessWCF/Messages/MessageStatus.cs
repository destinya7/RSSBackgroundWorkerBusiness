using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSBackgroundWorkerBusinessWCF.Messages
{
    public enum MessageStatus
    {
        Created,
        Updated,
        Deleted,
        Error,
        NothingModified,
        NotFound
    }
}