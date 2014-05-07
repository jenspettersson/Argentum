using System;
using System.Collections.Generic;

namespace SilverScreen.Domain
{
	public class Booking : AggregateBase<BookingState>
	{
		public Booking(BookingState state) : base(state) { }
	}

	public class BookingState : State
	{
		public Guid BookableShowId { get; set; }

		public List<Seat> BookedSeats { get; set; }
	}
}