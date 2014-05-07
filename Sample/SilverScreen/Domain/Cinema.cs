﻿using System.Collections.Generic;

namespace SilverScreen.Domain
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