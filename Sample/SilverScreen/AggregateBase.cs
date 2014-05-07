using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen
{
    public abstract class AggregateBase<TState> where TState : IState, new()
    {
        protected TState State;
        protected AggregateBase()
        {
            State = new TState();
        }
        protected AggregateBase(TState state)
        {
            State = state;
        }

        public IList<IEvent> Changes = new List<IEvent>();

        public void Apply(IEvent evt)
        {
            State.Mutate(evt);
            Changes.Add(evt);
        }
    }
}