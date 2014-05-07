namespace SilverScreen.Domain
{
	public class ScreenLayout
	{
		public int TotalSeats
		{
			get { return SeatsPerRow*Rows; }
		}

		public int Rows { get; private set; }

		public int SeatsPerRow { get; private set; }
	}
}