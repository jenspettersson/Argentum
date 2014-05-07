using System.Collections.Generic;

namespace Argentum.Core
{
    public interface IBus : IUnitOfWork
    {
        void Publish(object message);
        void Publish(IEnumerable<object> messages);
    }
}