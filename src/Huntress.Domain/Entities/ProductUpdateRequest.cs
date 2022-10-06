namespace Huntress.Domain.Entities;

public class ProductUpdateRequest
{
    public Guid ProductUpdateRequestId { get; set; }
    public string Email { get; set; } = "";
    public Guid ProductId { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public ProductUpdateRequest(string email, Guid productId)
    {
        Email = email;
        ProductId = productId;
    }

    public ProductUpdateRequest()
    {

    }
}
