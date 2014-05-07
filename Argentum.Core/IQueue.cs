using System;

namespace Argentum.Core
{
    public interface IQueue
    {
        void Put(object item);
        void Pop(Action<object> popAction);
    }
}