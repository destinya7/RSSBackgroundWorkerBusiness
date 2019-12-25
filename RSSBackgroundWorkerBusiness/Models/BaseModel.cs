using System;

namespace RSSBackgroundWorkerBusiness.Models
{
    public abstract class BaseModel
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
