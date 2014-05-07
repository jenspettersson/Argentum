using System;
using Argentum.Core;

namespace SilverScreen.Domain.Cinema
{
	public class CinemaAdded : IEvent
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public CinemaAdded(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}