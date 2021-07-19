using System;

namespace Huntress.Api.Models
{
    public class ProductUpdateRequest
    {
        public Guid ProductUpdateRequestId { get; private set; }
        public string Email { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Updated { get; private set; }
        public ProductUpdateRequest(string email, Guid productId)
        {
            Email = email;
            ProductId = productId;
        }

        private ProductUpdateRequest()
        {

        }

        public void SetUpdated()
        {
            Updated = DateTime.UtcNow;
        }
    }
}
