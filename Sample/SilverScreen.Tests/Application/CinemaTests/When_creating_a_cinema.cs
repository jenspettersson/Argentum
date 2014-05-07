using FluentAssertions;
using SilverScreen.Application.Cinema;
using Xunit;

namespace SilverScreen.Tests.Application.CinemaTests
{
	public class When_creating_a_cinema
	{
		[Fact]
		public void Cinema_should_be_created()
		{
			var command = new AddCinema("test");

			var handler = new AddCinemaHandler();
			handler.HandleCommand(command);

			true.Should().BeFalse();
		}
	}
}
