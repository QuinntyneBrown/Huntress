using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Api.Models
{
    public class Content
    {
        public Guid ContentId { get; set; }
        public string Name { get; set; }
        public JObject Json { get; set; }
    }
}
