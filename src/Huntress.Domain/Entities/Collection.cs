using Huntress.Domain.Enums;
using System.Collections.Generic;

namespace Huntress.Domain.Entities;

public class Collection
{
    public Guid CollectionId { get; private set; }
    public CollectionType CollectionType { get; private set; } = CollectionType.Default;
    public List<CollectionItem> CollectionItems { get; private set; } = new();
    public Collection(CollectionType collectionType)
    {
        CollectionType = collectionType;
    }

    public Collection()
    {

    }
}
