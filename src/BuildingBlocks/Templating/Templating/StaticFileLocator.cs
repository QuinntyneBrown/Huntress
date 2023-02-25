// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;


namespace Templating;

public class StaticFileLocator: IStaticFileLocator
{
    public string GetAsString(string name)
    {
        var fullName = default(string);
        var assembly = default(Assembly);
        var embededResourceNames = new List<string>();

        foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var item in _assembly.GetManifestResourceNames()) embededResourceNames.Add(item);

                    if (!string.IsNullOrEmpty(_assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name)))
                    {
                        fullName = _assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name);
                        assembly = _assembly;
                    }
                }
                catch
                {

                }
            }
        }

        if (fullName == default && assembly == default)
            return null;

        try
        {
            using (var stream = assembly.GetManifestResourceStream(fullName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
        catch (Exception exception)
        {
            throw;
        }
    }
    public byte[] Get(string name)
    {
        var fullName = default(string);
        var assembly = default(Assembly);
        var embededResourceNames = new List<string>();

        foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var item in _assembly.GetManifestResourceNames()) embededResourceNames.Add(item);

                    if (!string.IsNullOrEmpty(_assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name)))
                    {
                        fullName = _assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name);
                        assembly = _assembly;
                    }
                }
                catch
                {

                }
            }
        }

        if (fullName == default && assembly == default)
            return null;

        try
        {
            using (var stream = assembly.GetManifestResourceStream(fullName))
            {
                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}

