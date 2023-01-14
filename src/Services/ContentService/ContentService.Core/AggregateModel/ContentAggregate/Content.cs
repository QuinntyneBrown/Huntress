using Newtonsoft.Json.Linq;

namespace ContentService.Core.AggregateModel.ContentAggregate;

public class Content {
    public Guid ContentId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public JObject Json { get; set; }
}