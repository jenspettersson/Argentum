using Argentum.Core;

namespace SilverScreen
{
    public class State : IState
    {
        public void Mutate(IEvent evt)
        {
            ((dynamic)this).When((dynamic)evt);
        }
    }
}