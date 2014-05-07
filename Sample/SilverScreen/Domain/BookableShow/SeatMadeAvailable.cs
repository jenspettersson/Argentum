using System;
using Argentum.Core;

namespace SilverScreen.Domain.BookableShow
{
	public class SeatMadeAvailable : IEvent
	{
		public Guid BookableShowId { get; private set; }
		public Guid SeatId { get; private set; }

		public SeatMadeAvailable(Guid bookableShowId, Guid seatId)
		{
			BookableShowId = bookableShowId;
			SeatId = seatId;
		}
	}
}