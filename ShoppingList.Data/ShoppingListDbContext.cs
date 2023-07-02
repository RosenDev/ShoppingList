using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Domain;

namespace ShoppingList.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductList> ProductLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if(typeof(IDeleteable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var deletedCheck = Expression.Lambda(Expression.Equal(Expression.Property(parameter, "IsDeleted"), Expression.Constant(false)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(deletedCheck);
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfoRules();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IEntity &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach(var entry in changedEntries)
            {
                var entity = (IEntity)entry.Entity;

                if(entry.State == EntityState.Modified && entity.Updated == null)
                {
                    entity.Updated = DateTime.UtcNow;
                }
                else if(entry.State == EntityState.Deleted && entity.Deleted == null)
                {
                    entry.State = EntityState.Modified;
                    entity.Deleted = DateTime.UtcNow;
                    entity.IsDeleted = true;
                }
            }
        }
    }
}