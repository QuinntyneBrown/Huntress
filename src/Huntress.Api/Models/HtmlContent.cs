using System;

namespace Huntress.Api.Models
{
    public class HtmlContent
    {
        public Guid HtmlContentId { get; private set; }
        public HtmlContentType HtmlContentType { get; private set; }
        public string Name { get; private set; }
        public string Body { get; private set; }
        public HtmlContent(HtmlContentType htmlContentType, string name, string body)
        {
            HtmlContentType = htmlContentType;
            Name = name;
            Body = body;
        }

        private HtmlContent()
        {

        }
    }
}
