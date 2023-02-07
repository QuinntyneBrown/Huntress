// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace EventSourcing;

public class EventStore: IEventStore
{
    private readonly IDbConnection _connection;

    public EventStore(IDbConnectionProvider dbConnectionProvider)
    {
        _connection = dbConnectionProvider.Get();
    }

    public async Task Add(IDomainEvent domainEvent)
    {
        await _connection.ExecuteScalarAsync("insert StreamId, Type, Payload into DomainEvent payload", new
        {
            domainEvent.StreamId,
            domainEvent.Type,
            domainEvent.Created,
            domainEvent.Version,
            Payload = System.Text.Json.JsonSerializer.Serialize(domainEvent)
        });
    }

    public Task<IList<IDomainEvent>> Get(Guid streamId)
    {
        throw new NotImplementedException();
    }
}

