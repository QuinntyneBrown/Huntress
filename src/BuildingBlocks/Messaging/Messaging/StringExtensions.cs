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
