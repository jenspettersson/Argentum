using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain.Booking
{
	public class BookingCreated : IEvent
	{
		public Guid Id { get; private set; }
		public Guid BookableShowId { get; private set; }
		public List<Seat> BookedSeats { get; private set; }
		public DateTime Created { get; private set; }

		public BookingCreated(Guid id, Guid bookableShowId, List<Seat> bookedSeats, DateTime created)
		{
			Id = id;
			BookableShowId = bookableShowId;
			BookedSeats = bookedSeats;
			Created = created;
		}
	}
}