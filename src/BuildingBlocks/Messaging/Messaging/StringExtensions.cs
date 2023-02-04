// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace System;

public static class StringExtensions { 

    public static bool JsonIsTypeOf<T>(this string value)
    {
        if(string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
        {
            return false;
        }

        var jObject = JObject.Parse(value);

        var typeName = $"{jObject["$type"]}".Split(',')[0].Split('.').Last();

        return typeof(T).Name == typeName;
    }
}

