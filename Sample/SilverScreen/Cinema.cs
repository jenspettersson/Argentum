using System.Collections.Generic;

namespace SilverScreen
{
	public class Cinema
	{
		private readonly List<Screen> _screens = new List<Screen>();

		public IEnumerable<Screen> Screens
		{
			get { return _screens; }
		}
	}
}
