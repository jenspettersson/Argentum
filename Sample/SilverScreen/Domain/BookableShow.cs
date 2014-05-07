using System;
using System.Collections.Generic;

namespace SilverScreen.Domain
{
	public class BookableShow : AggregateBase<BookableShowState>
	{
		public BookableShow(BookableShowState state) : base(state) { }
	}

	public class BookableShowState : State
	{
		public Guid ScreenId { get; set; }

		public DateTime ShowTime { get; set; }

		public List<BookableSeat> Seats { get; set; } 
	}
}