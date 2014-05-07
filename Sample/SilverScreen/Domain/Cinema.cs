using System.Collections.Generic;

namespace SilverScreen.Domain
{
	public class Cinema : AggregateBase<CinemaState>
	{
		public Cinema(CinemaState state) : base(state) { }
	}

	public class CinemaState : State
	{
		public List<Screen> Screens { get; set; }
	}
}
