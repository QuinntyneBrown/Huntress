using Huntress.Api.Models;
using System.Linq;

namespace Huntress.Api.Data
{
    public static class SeedData
    {
        public static void Seed(HuntressDbContext context)
        {
            DigitalAssetConfiguration.Seed(context);
            ImageContentConfiguration.Seed(context);            
            ProductConfiguration.Seed(context);
            
        }

        internal static class ImageContentConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                var imageContent = context.ImageContents.SingleOrDefault(x => x.ImageContentType == Models.ImageContentType.Hero);

                if (imageContent == null)
                {
                    var digitalAsset = context.DigitalAssets.Single(x => x.Name == "hero-1.jpg");

                    imageContent = new(Models.ImageContentType.Hero, $"api/DigitalAsset/serve/{digitalAsset.DigitalAssetId}");

                    context.ImageContents.Add(imageContent);

                    context.SaveChanges();
                }

                context.ChangeTracker.Clear();
            }
        }

        internal static class ProductConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                DigitalAssetConfiguration.SeedProductImages(context);

                for(var i = 1; i <=5; i++)
                {
                    var product = context.Products.SingleOrDefault(x => x.Name == $"");

                    if(product == null)
                    {
                        product = new (default, default, default);

                        var digitalAsset = context.DigitalAssets.Single(x => x.Name == $"product-{i}.jpg");

                        product.ProductImages.Add(new(default, $"api/DigitalAsset/serve/{digitalAsset.DigitalAssetId}"));

                        context.Products.Add(product);

                        context.SaveChanges();
                    }
                }

            }
        }
    }
}
