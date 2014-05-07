namespace SilverScreen
{
	public class BookableSeat
	{
		public int RowNumber { get; private set; }

		public int SeatNumber { get; private set; }

		public BookableSeatStatus Status { get; private set; }
	}
}