using System;

namespace UMDB
{
	public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
	{
		void Apply(TEvent evt);
	}

	public interface IDomainEvent
	{
	    Guid Id { get; }
	}
    public class DomainEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        
        public DomainEvent()
        {
            Id = Guid.NewGuid();
        }
    }
	
}