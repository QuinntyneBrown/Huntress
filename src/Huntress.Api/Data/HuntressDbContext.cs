using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Data
{
    public class HuntressDbContext : DbContext, IHuntressDbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Collection> Collections { get; private set; }
        public DbSet<InstagramFeedItem> InstagramFeedItems { get; private set; }
        public DbSet<InstagramFeed> InstagramFeeds { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<CollectionItem> CollectionItems { get; private set; }
        public DbSet<ProductImage> ProductImages { get; private set; }
        public DbSet<CustomerCollection> CustomerCollections { get; private set; }
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
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public DbSet<DashboardCard> DashboardCards { get; private set; }
        public DbSet<Content> Contents { get; private set; }
        public HuntressDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HuntressDbContext).Assembly);
        }

    }
}
