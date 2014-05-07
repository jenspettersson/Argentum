using System;
using System.Collections.Generic;

namespace SilverScreen.Domain
{
	public class Booking
	{
		private readonly List<Seat> _bookedSeats = new List<Seat>();

		public Guid BookableShowId { get; private set; }

		public IEnumerable<Seat> BookedSeats
		{
			get { return _bookedSeats; }
		}
	}
}