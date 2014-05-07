using Argentum.Core;

namespace SilverScreen
{
    public interface IState
    {
        void Mutate(IEvent evt);
    }
}