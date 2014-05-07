using Argentum.Core;

namespace SilverScreen.Application.Cinema
{
    public class AddCinema: ICommand
    {
        public string Name { get; set; }

        public AddCinema(string name)
        {
            Name = name;
        }
    }
}