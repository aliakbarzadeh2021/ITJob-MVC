using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Advertisement.Aggregates;

namespace ITJob.Repository.Context
{
    public class EntityFrameworkDbContext : DbContext
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public EntityFrameworkDbContext() :base(ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Advertisement>().ToTable("Advertisement");
        }
    }
}
