namespace UMDB
{
	public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
	{
		void Apply(TEvent evt);
	}

	public interface IDomainEvent
	{

	}

	public class MovieCreated : IDomainEvent
	{

	}
}