using System;
using System.Collections.Generic;

namespace SilverScreen.Domain.Booking
{
	public class BookingState : State
	{
		public Guid BookableShowId { get; set; }

		public List<Seat> BookedSeats { get; set; }
		
		public DateTime Created { get; set; }

		public void When(BookingCreated evt)
		{
			Id = evt.Id;
			BookableShowId = evt.BookableShowId;
			BookedSeats = evt.BookedSeats;
			Created = evt.Created;
		}
	}
}