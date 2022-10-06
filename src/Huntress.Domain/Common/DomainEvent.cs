using MediatR;
using System;

namespace Huntress.Domain.Common
{
    public class DomainEvent : INotification
    {
        public DateTime Created { get; private set; } = DateTime.UtcNow;
    }
}
