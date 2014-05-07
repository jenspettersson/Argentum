using FluentAssertions;
using SilverScreen.Application;
using Xunit;

namespace SilverScreen.Tests.Application
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
