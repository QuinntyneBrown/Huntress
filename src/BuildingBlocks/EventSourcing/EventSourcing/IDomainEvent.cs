using System;

namespace EventSourcing;

public interface IDomainEvent
{
    Guid StreamId { get; }
    string Type { get; }
    DateTime Created { get; }
    int Version { get; }
}
