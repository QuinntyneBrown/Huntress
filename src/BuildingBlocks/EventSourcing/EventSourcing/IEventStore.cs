// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSourcing;

public interface IEventStore
{
    Task Add(IDomainEvent domainEvent);
    Task<IList<IDomainEvent>> Get(Guid streamId);
}

