// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Templating;

public static class StringListExtensions
{
    public static string SingleOrDefaultResourceName(this string[] collection, string name)
    {
        try
        {
            string result = null;

            if (collection.Length == 0) return null;

            result = collection.SingleOrDefault(x => x.EndsWith(name));

            if (result != null)
                return result;

            return collection.SingleOrDefault(x => x.EndsWith($".{name}.txt"));

        }
        catch (Exception e)
        {
            throw;
        }
    }
}

