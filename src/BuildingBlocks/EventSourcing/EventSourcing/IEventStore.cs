using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSourcing;

public interface IEventStore
{
    Task Add(IDomainEvent domainEvent);
    Task<IList<IDomainEvent>> Get(Guid streamId);
}
