using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Huntress.Api.Data
{
    public class HuntressDbContext : DbContext, IHuntressDbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Collection> Collections { get; private set; }
        public DbSet<InstagramFeedItem> InstagramFeedItems { get; private set; }
        public DbSet<InstagramFeed> InstagramFeeds { get; private set; }
        public DbSet<HtmlContent> HtmlContents { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<CollectionItem> CollectionItems { get; private set; }
        public DbSet<ProductImage> ProductImages { get; private set; }
        public DbSet<CustomerCollection> CustomerCollections { get; private set; }
        public DbSet<ImageContent> ImageContents { get; private set; }
        public DbSet<ProductCollection> ProductCollections { get; private set; }
        public DbSet<SocialShare> SocialShares { get; private set; }
        public DbSet<CssVariable> CssVariables { get; private set; }
        public DbSet<Order> Orders { get; private set; }
        public DbSet<OrderItem> OrderItems { get; private set; }
        public DbSet<ProductUpdateRequest> ProductUpdateRequests { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Privilege> Privileges { get; private set; }
        public DbSet<Theme> Themes { get; private set; }
        public DbSet<JsonContent> JsonContents { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public DbSet<DashboardCard> DashboardCards { get; private set; }
        public HuntressDbContext(DbContextOptions options)
            : base(options)
        {
            SavingChanges += DbContext_SavingChanges;
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HuntressDbContext).Assembly);
        }

        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;

            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;

            return base.DisposeAsync();
        }

    }
}
