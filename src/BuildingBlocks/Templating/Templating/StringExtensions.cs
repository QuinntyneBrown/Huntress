using static Templating.NamingConvention;

namespace Templating;

public static class StringExtensions
{
    public static string Slugify(this string value)
        => new NamingConventionConverter().Convert(Slug, value);
}
