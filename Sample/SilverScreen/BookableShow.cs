using System;
using System.Collections.Generic;

namespace SilverScreen
{
	public class BookableShow
	{
		private readonly List<BookableSeat> _seats = new List<BookableSeat>(); 

		public Guid ScreenId { get; private set; }

		public DateTime ShowTime { get; private set; }

		public IEnumerable<BookableSeat> Seats{get { return _seats; }} 
	}
}