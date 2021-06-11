using System.Linq;

namespace Huntress.Api.Data
{
    public static class SeedData
    {
        public static void Seed(HuntressDbContext context)
        {
            DigitalAssetConfiguration.Seed(context);
            ImageContentConfiguration.Seed(context);
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
            }
        }
    }
}
