using System;
using System.Collections.Generic;

namespace UMDB
{
	public class Movie : IEntity, IDomainEventHandler<MovieCreated>
	{
		public MovieInformationId MovieInformationId { get; private set; }

		public IEnumerable<Review> Reviews { get; private set; }
		
		public IEnumerable<Rating> Ratings { get; private set; }

		public Movie()
		{
			Reviews = new List<Review>();
			Ratings = new List<Rating>();
		}

		public void Rate(int rate)
		{
			throw new NotImplementedException();
		}

		public void Apply(MovieCreated evt)
		{
			throw new NotImplementedException();
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