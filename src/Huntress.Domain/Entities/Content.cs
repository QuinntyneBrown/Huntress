using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Domain.Entities;

public class Content
{
    public Guid ContentId { get; set; }
    public string Name { get; set; } = "";
    public JObject Json { get; set; } = null!;
    public string Slug { get; set; } = "";

    public Content()
    {

    }
}
