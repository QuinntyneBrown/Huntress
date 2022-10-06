using Huntress.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Domain.Interfaces;

public interface IHuntressDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Collection> Collections { get; }
    DbSet<InstagramFeedItem> InstagramFeedItems { get; }
    DbSet<InstagramFeed> InstagramFeeds { get; }
    DbSet<DigitalAsset> DigitalAssets { get; }
    DbSet<CollectionItem> CollectionItems { get; }
    DbSet<ProductImage> ProductImages { get; }
    DbSet<CustomerCollection> CustomerCollections { get; }
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
    DbSet<StoredEvent> StoredEvents { get; }
    DbSet<DashboardCard> DashboardCards { get; }
    DbSet<Content> Contents { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
