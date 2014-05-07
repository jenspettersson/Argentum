using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain
{
	public class Cinema : AggregateBase<CinemaState>
	{
		public Cinema(CinemaState state) : base(state) { }

		private Cinema(string name)
        {
            Apply(new CinemaCreated(name));
        }

		public static Cinema Create(string name, string adress)
        {
			return new Cinema(name);
        }
	}

	public class CinemaState : State
	{
		public string Name { get; set; }

		public List<Screen> Screens { get; set; }

		public void When(CinemaCreated evt)
		{
			Name = evt.Name;
		}
	}

	public class CinemaCreated : IEvent
	{
		public string Name { get; private set; }

		public CinemaCreated(string name)
		{
			Name = name;
		}
	}
}
