using System;

namespace SilverScreen.Domain.BookableShow
{
	public class BookableSeat
	{
		public Guid Id { get; private set; }

		public int RowNumber { get; private set; }

		public int SeatNumber { get; private set; }

		public BookableSeatStatus Status { get; set; }

		public BookableSeat()
		{
			Id = Guid.NewGuid();
		}
	}
}