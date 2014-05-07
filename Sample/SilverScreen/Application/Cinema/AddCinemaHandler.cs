using Argentum.Core;

namespace SilverScreen.Application.Cinema
{
	public class AddCinemaHandler : IHandleCommand<AddCinema>
	{
		public void HandleCommand(AddCinema command)
		{
			var cinema = Domain.Cinema.Cinema.Add(command.Name);
		}
	}
}