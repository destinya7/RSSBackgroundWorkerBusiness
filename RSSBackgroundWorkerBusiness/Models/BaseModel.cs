using System;

namespace RSSBackgroundWorkerBusiness.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
