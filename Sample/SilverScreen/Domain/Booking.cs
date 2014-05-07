using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain
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