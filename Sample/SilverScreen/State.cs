using System;
using Argentum.Core;

namespace SilverScreen
{
    public class State : IState
    {
        public Guid Id { get; set; }

        public void Mutate(IEvent evt)
        {
            ((dynamic)this).When((dynamic)evt);
        }
    }
}