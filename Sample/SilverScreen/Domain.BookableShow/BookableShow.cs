using System;
using System.Collections.Generic;

namespace SilverScreen.Domain.BookableShow
{
	public class BookableShow : AggregateBase<BookableShowState>
	{
		public BookableShow(BookableShowState state) : base(state) { }

		private BookableShow(Guid id, Guid screenId, DateTime showTime, List<BookableSeat> seats)
		{
			Apply(new BookableShowCreated(id, screenId, showTime, seats));
		}

		public static BookableShow Create(Guid id, Guid screenId, DateTime showTime, List<BookableSeat> seats)
		{
			return new BookableShow(Guid.NewGuid(), screenId, showTime, seats);
		}

		public void MakeSeatAvailable(Guid seatId)
		{
			Apply(new SeatMadeAvailable(Id, seatId));
		}

		public void ReserveSeat(Guid seatId)
		{
			Apply(new SeatReserved(Id, seatId));
		}

		public void BookSeat(Guid seatId)
		{
			Apply(new SeatBooked(Id, seatId));
		}
	}
}