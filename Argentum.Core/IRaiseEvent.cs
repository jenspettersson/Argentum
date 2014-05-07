namespace Argentum.Core
{
    public interface IRaiseEvent
    {
        void Raise(IEvent evt);
    }
}