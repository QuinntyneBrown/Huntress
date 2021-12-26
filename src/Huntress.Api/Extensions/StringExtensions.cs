using Huntress.Api.Core;
using static Huntress.Api.Core.NamingConvention;

namespace Huntress.Api.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string value)
            => new NamingConventionConverter().Convert(Slug, value);
    }
}
