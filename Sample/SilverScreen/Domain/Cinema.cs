using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain
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

	public class CinemaState : State
	{
		public string Name { get; set; }

		public List<Screen> Screens { get; set; }

		public void When(CinemaAdded evt)
		{
			Id = evt.Id;
			Name = evt.Name;
		}
	}

	public class CinemaAdded : IEvent
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public CinemaAdded(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
