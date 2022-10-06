using Huntress.Domain.Common;
using static Huntress.Domain.Common.NamingConvention;

namespace Huntress.Api.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string value)
            => new NamingConventionConverter().Convert(Slug, value);
    }
}
