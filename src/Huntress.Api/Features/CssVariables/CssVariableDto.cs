using System;

namespace Huntress.Api.Features
{
    public class CssVariableDto
    {
        public Guid CssVariableId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
