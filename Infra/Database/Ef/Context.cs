using Domain.Common.Entities;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Ef
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => p.DeletedAt == null);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=ecomapi;Pooling=true;")
                .UseSnakeCaseNamingConvention();

        public override int SaveChanges()
        {
            UseUpdatedAndCreatedAt();
            UseSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UseUpdatedAndCreatedAt();
            UseSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UseUpdatedAndCreatedAt()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && x.State is EntityState.Added or EntityState.Modified);

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity) entity.Entity).CreatedAt = DateTime.UtcNow;
                }

                ((BaseEntity) entity.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        private void UseSoftDelete()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                            e.Metadata.GetProperties().Any(x => x.Name == "DeletedAt"));

            foreach (var item in entities)
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["DeletedAt"] = DateTime.UtcNow;
            }
        }
    }
}