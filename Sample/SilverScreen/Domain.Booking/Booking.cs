using System;
using System.Collections.Generic;

namespace SilverScreen.Domain.Booking
{
	public class Booking : AggregateBase<BookingState>
	{
		public Booking(BookingState state) : base(state) { }

		private Booking(Guid id, Guid bookableShowId, List<Seat> bookedSeats, DateTime created)
		{
			Apply(new BookingCreated(id, bookableShowId, bookedSeats, created));
		}

		public static Booking Create(Guid bookableShowId, List<Seat> bookedSeats)
		{
			return new Booking(Guid.NewGuid(), bookableShowId, bookedSeats, DateTime.UtcNow);
		}
	}
}