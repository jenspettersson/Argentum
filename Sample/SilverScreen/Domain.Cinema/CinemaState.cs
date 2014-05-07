using System.Collections.Generic;

namespace SilverScreen.Domain.Cinema
{
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
}