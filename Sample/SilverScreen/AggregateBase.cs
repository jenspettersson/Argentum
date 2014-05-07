using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen
{
    public abstract class AggregateBase<TState> : IAggregate where TState : IState, new()
    {
        public Guid Id { get { return State.Id; } }
        public IEnumerable<IEvent> GetUncommittedEvents()
        {
            return _changes;
        }

        public void Clear()
        {
            _changes.Clear();
        }

        protected TState State;
        protected AggregateBase()
        {
            State = new TState();
        }

        protected AggregateBase(TState state)
        {
            State = state;
        }

        private readonly IList<IEvent> _changes = new List<IEvent>();

        public void Apply(IEvent evt)
        {
            State.Mutate(evt);
            _changes.Add(evt);
        }
    }
}