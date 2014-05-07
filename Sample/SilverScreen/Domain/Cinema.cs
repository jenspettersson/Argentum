using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain
{
	public class Cinema : AggregateBase<CinemaState>
	{
		public Cinema(CinemaState state) : base(state) { }

		private Cinema(string name)
        {
            Apply(new CinemaAdded(name));
        }

		public static Cinema Add(string name)
        {
			return new Cinema(name);
        }
	}

	public class CinemaState : State
	{
		public string Name { get; set; }

		public List<Screen> Screens { get; set; }

		public void When(CinemaAdded evt)
		{
			Name = evt.Name;
		}
	}

	public class CinemaAdded : IEvent
	{
		public string Name { get; private set; }

		public CinemaAdded(string name)
		{
			Name = name;
		}
	}
}
