using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using Huntress.Api.Models;
using Huntress.Api.Core;

namespace Huntress.Api.Data
{
    internal static class DigitalAssetConfiguration
    {
        internal static void Seed(HuntressDbContext context)
        {
            if (context.DigitalAssets.SingleOrDefault(x => x.Name == "hero-1.jpg") == null)
            {
                var provider = new FileExtensionContentTypeProvider();

                provider.TryGetContentType("hero-1.jpg", out string contentType);

                var d = new DigitalAsset
                {
                    Name = "hero-1.jpg",
                    Bytes = StaticFileLocator.Get("hero-1.jpg"),
                    ContentType = contentType
                };

                context.DigitalAssets.Add(d);
                context.SaveChanges();

                var id = d.DigitalAssetId;
            }
        }
    }
}
