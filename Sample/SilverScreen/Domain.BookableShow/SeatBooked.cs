using System;
using Argentum.Core;

namespace SilverScreen.Domain.BookableShow
{
	public class SeatBooked : IEvent
	{
		public Guid BookableShowId { get; private set; }
		public Guid SeatId { get; private set; }

		public SeatBooked(Guid bookableShowId, Guid seatId)
		{
			BookableShowId = bookableShowId;
			SeatId = seatId;
		}
	}
}