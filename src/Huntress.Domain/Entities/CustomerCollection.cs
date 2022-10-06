using Huntress.Domain.Enums;

namespace Huntress.Domain.Entities;

public class CustomerCollection : Collection
{
    public Guid CustomerCollectionId { get; private set; }
    public CustomerCollectionType CustomerCollectionType { get; private set; }
    public Guid CustomerId { get; private set; }
    public CustomerCollection(CustomerCollectionType customerCollectionType, Guid customerId)
    {
        CustomerCollectionType = customerCollectionType;
        CustomerId = customerId;
    }

    private CustomerCollection()
    {

    }
}
