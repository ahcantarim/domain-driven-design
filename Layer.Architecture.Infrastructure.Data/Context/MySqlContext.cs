using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Layer.Architecture.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<SomeEntity> SomeEntityDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SomeEntity>(new SomeEntityMap().Configure);
        }
    }
}
