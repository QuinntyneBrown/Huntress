using Huntress.Api.Models;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Data
{
    public class HuntressDbContext: DbContext, IHuntressDbContext
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
        public HuntressDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HuntressDbContext).Assembly);
        }
        
    }
}
