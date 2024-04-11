using CookieCookbook.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Data;

public class FileMetadata
{
    public string Name { get;}
    public FileFormat Format { get;}

    public FileMetadata(string name, FileFormat format)
    {
        Name = name;
        Format = format;
    }
    public string ToPath() => $"{Name}.{Format.AsFileFormatExtension()}";
}
