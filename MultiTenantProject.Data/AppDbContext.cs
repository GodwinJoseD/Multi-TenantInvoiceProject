using Microsoft.EntityFrameworkCore;
using MultiTenantProject.Core;
using MultiTenantProject.Model;
using System.Reflection.Emit;

namespace MultiTenantProject.Data
{
    public class AppDbContext:DbContext
    {
        private readonly ITenantProvider _tenantProvider;
        public AppDbContext(DbContextOptions<AppDbContext> options,
                        ITenantProvider tenantProvider)
        : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Invoice> Invoices => Set<Invoice>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasQueryFilter(p =>
                    !p.IsDeleted &&
                    p.TenantId == _tenantProvider.GetTenantId());
        }
        public override int SaveChanges()
        {
            ApplyAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            ApplyAudit();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAudit()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.TenantId = _tenantProvider.GetTenantId();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

    }
}
