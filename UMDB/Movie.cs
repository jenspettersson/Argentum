using System;
using System.Collections.Generic;

namespace UMDB
{
    public class AggregateRoot<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        private readonly Dictionary<Type, Action<TDomainEvent>> _registeredEvents;
        private readonly List<TDomainEvent> _appliedEvents;
        public AggregateRoot()
        {
            _registeredEvents = new Dictionary<Type, Action<TDomainEvent>>();
            _appliedEvents = new List<TDomainEvent>();
        }

        protected void RegisterEvent<TEvent>(Action<TEvent> eventHandler) where TEvent : class, TDomainEvent
        {
            _registeredEvents.Add(typeof(TEvent), theEvent => eventHandler(theEvent as TEvent));
        }

        protected void Apply<TEvent>(TEvent domainEvent) where TEvent : class, TDomainEvent
        {
            HandleEvent(domainEvent.GetType(), domainEvent);
            _appliedEvents.Add(domainEvent);
        }

        private void HandleEvent(Type eventType, TDomainEvent domainEvent)
        {
            Action<TDomainEvent> handler;

            if (!_registeredEvents.TryGetValue(eventType, out handler))
                throw new Exception(string.Format("The requested domain event '{0}' is not registered in '{1}'", eventType.FullName, GetType().FullName));

            handler(domainEvent);
        }
    }
    public class MovieCreated : DomainEvent
    {
        public MovieId MovieId { get; private set; }
        public string Name { get; private set; }

        public MovieCreated(MovieId id, string name)
        {
            MovieId = id;
            Name = name;
        }
    }

	public class Movie : AggregateRoot<IDomainEvent>
	{
		public MovieInformationId MovieInformationId { get; private set; }

	    public string Name { get; private set; }
		public IEnumerable<Review> Reviews { get; private set; }
		
		public IEnumerable<Rating> Ratings { get; private set; }

		public Movie()
		{
			Reviews = new List<Review>();
			Ratings = new List<Rating>();

            RegisterEvents();
		}

        private Movie(string name) : this()
        {
            Apply(new MovieCreated(new MovieId("id"), name));
        }

        public static Movie Create(string name)
        {
            return new Movie(name);
        }

		public void Rate(int rate)
		{
			throw new NotImplementedException();
		}

		private void MovieCreated(MovieCreated evt)
		{
		    Name = evt.Name;
		}

        private void RegisterEvents()
        {
            RegisterEvent<MovieCreated>(MovieCreated);
        }
	}

    public class MovieId
    {
        public string Id { get; private set; }

        public MovieId(string id)
        {
            Id = id;
        }
    }

    public class MovieInformation : IEntity
	{
		public MovieInformationId MovieInformationId { get; private set; }

		public string Plot { get; private set; }

		public DateTime ReleaseDate { get; private set; }

		public IEnumerable<ActorId> Actors { get; private set; }

		public IEnumerable<DirectorId> Directors { get; private set; }

		public IEnumerable<ProducerId> Producers { get; private set; }

		public Genre Genre { get; private set; }

		public MovieInformation()
		{
			Actors = new List<ActorId>();
			Directors = new List<DirectorId>();
			Producers = new List<ProducerId>();
		}
	}
}