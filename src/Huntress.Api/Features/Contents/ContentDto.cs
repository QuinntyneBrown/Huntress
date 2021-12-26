using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Api.Features
{
    public class ContentDto
    {
        public Guid ContentId { get; set; }
        public string Name { get; set; }
        public JObject Json { get; set; }
        public string Slug { get; set; }
    }
}
