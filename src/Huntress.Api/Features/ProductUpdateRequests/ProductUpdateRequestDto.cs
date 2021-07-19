using System;

namespace Huntress.Api.Features
{
    public class ProductUpdateRequestDto
    {
        public Guid? ProductUpdateRequestId { get; set; }
        public string Email { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
