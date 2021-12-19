using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Api.Models
{
    public class JsonContent
    {
        public Guid JsonContentId { get; set; }
        public string Name { get; set; }
        public JObject Json { get; set; }
    }
}
