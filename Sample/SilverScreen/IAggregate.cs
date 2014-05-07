using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen
{
    public interface IAggregate
    {
        Guid Id { get; }
        IEnumerable<IEvent> GetUncommittedEvents();
    }
}