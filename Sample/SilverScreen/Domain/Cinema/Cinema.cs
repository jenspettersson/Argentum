using System;

namespace SilverScreen.Domain.Cinema
{
	public class Cinema : AggregateBase<CinemaState>
	{
		public Cinema(CinemaState state) : base(state) { }

		private Cinema(Guid id, string name)
        {
            Apply(new CinemaAdded(id, name));
        }

		public static Cinema Add(string name)
        {
			return new Cinema(Guid.NewGuid(), name);
        }
	}
}
