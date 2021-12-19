using Huntress.Api.Core;
using Huntress.Api.Models;
using Microsoft.AspNetCore.StaticFiles;
using System.Collections.Generic;
using System.Linq;

namespace Huntress.Api.Data
{
    public static class SeedData
    {
        public static void Seed(HuntressDbContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            DigitalAssetConfiguration.Seed(context);
            ProductConfiguration.Seed(context);
            SocialShareConfiguration.Seed(context);
            CssVariableConfiguration.Seed(context);
        }

        internal static class DigitalAssetConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                if (context.DigitalAssets.SingleOrDefault(x => x.Name == "hero-1.jpg") == null)
                {
                    var provider = new FileExtensionContentTypeProvider();

                    provider.TryGetContentType("hero-1.jpg", out string contentType);

                    var digitalAsset = new DigitalAsset
                    {
                        Name = "hero-1.jpg",
                        Bytes = StaticFileLocator.Get("hero-1.jpg"),
                        ContentType = contentType
                    };

                    context.DigitalAssets.Add(digitalAsset);

                    context.SaveChanges();
                }
            }

            internal static void SeedProductImages(HuntressDbContext context)
            {
                for (var i = 1; i <= 5; i++)
                {
                    var provider = new FileExtensionContentTypeProvider();

                    provider.TryGetContentType($"product-{i}.jpg", out string contentType);

                    var digitalAsset = new DigitalAsset
                    {
                        Name = $"product-{i}.jpg",
                        Bytes = StaticFileLocator.Get($"product-{i}.jpg"),
                        ContentType = contentType
                    };

                    context.DigitalAssets.Add(digitalAsset);

                    context.SaveChanges();
                }
            }
        }
        internal static class CssVariableConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                var cssVariable = context.CssVariables.SingleOrDefault(x => x.Name == "--background-color");

                if (cssVariable == null)
                {
                    cssVariable = new("--background-color", "#fff");

                    context.CssVariables.Add(cssVariable);

                    context.SaveChanges();
                }
            }
        }

        internal static class ProductConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                DigitalAssetConfiguration.SeedProductImages(context);

                for (var i = 1; i <= 5; i++)
                {
                    var product = context.Products.SingleOrDefault(x => x.Name == $"");

                    if (product == null)
                    {
                        product = new("Name", 99.99m, "Description");

                        var digitalAsset = context.DigitalAssets.Single(x => x.Name == $"product-{i}.jpg");

                        product.ProductImages.Add(new(default, $"api/DigitalAsset/serve/{digitalAsset.DigitalAssetId}"));

                        product.AddStock(1);

                        context.Products.Add(product);

                        context.SaveChanges();
                    }
                }

            }
        }
        internal static class SocialShareConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                foreach (var socialShare in new List<SocialShare> {
                    new (SocialShareType.Facebook,"https//www.facebook.com"),
                    new (SocialShareType.Twitter,"https//www.twitter.com"),
                    new (SocialShareType.Instagram,"https//www.instagram.com")
                })
                {
                    AddIfDoesntExist(socialShare);
                }

                context.SaveChanges();

                void AddIfDoesntExist(SocialShare socialShare)
                {
                    if (context.SocialShares.FirstOrDefault(x => x.ShareType == socialShare.ShareType) == null)
                    {
                        context.SocialShares.Add(socialShare);
                    }
                }
            }
        }

        internal static class RoleConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                foreach (var role in new List<Role>
                {
                    new (Constants.Roles.Customer),
                    new (Constants.Roles.Admin),
                })
                {
                    if (context.Roles.FirstOrDefault(x => x.Name == role.Name) == null)
                    {
                        foreach (var aggregate in Constants.Aggregates.All)
                        {
                            var accessRights = role.Name == Constants.Roles.Admin ? Constants.AccessRights.FullAccess : Constants.AccessRights.Read;

                            foreach (var accessWrite in accessRights)
                            {
                                role.Privileges.Add(new(accessWrite, aggregate));
                            }
                        }

                        context.Roles.Add(role);
                    }

                    context.SaveChanges();
                }
            }
        }

        internal static class UserConfiguration
        {
            internal static void Seed(HuntressDbContext context)
            {
                var passwordHasher = new PasswordHasher();

                foreach (var user in new List<User>
                {
                    new (Constants.Roles.Customer, "P@ssw0rd", passwordHasher),
                    new (Constants.Roles.Admin, "P@ssw0rd", passwordHasher),
                })
                {
                    if (context.Users.FirstOrDefault(x => x.Username == user.Username) == null)
                    {
                        var role = context.Roles.Single(x => x.Name == user.Username);

                        user.Roles.Add(role);

                        context.Users.Add(user);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
