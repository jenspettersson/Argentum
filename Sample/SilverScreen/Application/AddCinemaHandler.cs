using Argentum.Core;
using SilverScreen.Domain;
using SilverScreen.Domain.Cinema;

namespace SilverScreen.Application
{
	public class AddCinemaHandler : IHandleCommand<AddCinema>
	{
		public void HandleCommand(AddCinema command)
		{
			var cinema = Cinema.Add(command.Name);
		}
	}
}