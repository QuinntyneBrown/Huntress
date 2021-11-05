using Huntress.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Huntress.Api.Interfaces
{
    public interface IHuntressDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Collection> Collections { get; }
        DbSet<InstagramFeedItem> InstagramFeedItems { get; }
        DbSet<InstagramFeed> InstagramFeeds { get; }
        DbSet<HtmlContent> HtmlContents { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<CollectionItem> CollectionItems { get; }
        DbSet<ProductImage> ProductImages { get; }
        DbSet<CustomerCollection> CustomerCollections { get; }
        DbSet<ImageContent> ImageContents { get; }
        DbSet<ProductCollection> ProductCollections { get; }
        DbSet<SocialShare> SocialShares { get; }
        DbSet<CssVariable> CssVariables { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<ProductUpdateRequest> ProductUpdateRequests { get; }
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Privilege> Privileges { get; }
        DbSet<Theme> Themes { get; }
        DbSet<JsonContent> JsonContents { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        DbSet<DashboardCard> DashboardCards { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
