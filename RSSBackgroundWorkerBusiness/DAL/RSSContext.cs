using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.DAL
{
    public class RSSContext : DbContext
    {
        public RSSContext() : base("RSS_CONN_DEFAULT")
        {
        }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
