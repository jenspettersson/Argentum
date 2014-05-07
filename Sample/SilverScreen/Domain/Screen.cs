using System;
using System.Collections.Generic;

namespace SilverScreen.Domain
{
	public class Screen
	{
		private readonly List<DateTime> _showTimes = new List<DateTime>();

		public IEnumerable<DateTime> ShowTimes
		{
			get { return _showTimes; }
		}

		public ScreenLayout Layout { get; private set; }
	}
}