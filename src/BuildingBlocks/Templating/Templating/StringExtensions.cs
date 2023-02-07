// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using static Templating.NamingConvention;

namespace Templating;

public static class StringExtensions
{
    public static string Slugify(this string value)
        => new NamingConventionConverter().Convert(Slug, value);
}

