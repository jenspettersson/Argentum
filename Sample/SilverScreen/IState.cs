using System;
using Argentum.Core;

namespace SilverScreen
{
    public interface IState
    {
        Guid Id { get; set; }
        void Mutate(IEvent evt);
    }
}