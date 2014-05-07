namespace Argentum.Core
{
    public interface IHandleEvent<in TEvent> where TEvent : IEvent
    {
        void HandleEvent(TEvent evt);
    }
}