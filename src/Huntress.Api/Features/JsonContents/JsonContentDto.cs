using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Api.Features
{
    public class JsonContentDto
    {
        public Guid JsonContentId { get; set; }
        public string Name { get; set; }
        public JObject Json { get; set; }
    }
}
