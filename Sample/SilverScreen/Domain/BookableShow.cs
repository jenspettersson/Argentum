using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Domain
{
	public class BookableShow : AggregateBase<BookableShowState>
	{
		public BookableShow(BookableShowState state) : base(state) { }

		private BookableShow(Guid id, Guid screenId, DateTime showTime, List<BookableSeat> seats)
		{
			Apply(new BookableShowCreated(id, screenId, showTime, seats));
		}

		public static BookableShow Create(Guid id, Guid screenId, DateTime showTime, List<BookableSeat> seats)
		{
			return new BookableShow(Guid.NewGuid(), screenId, showTime, seats);
		}
	}

	public class BookableShowState : State
	{
		public Guid ScreenId { get; set; }

		public DateTime ShowTime { get; set; }

		public List<BookableSeat> Seats { get; set; }

		public void When(BookableShowCreated evt)
		{
			Id = evt.Id;
			ScreenId = evt.ScreenId;
			ShowTime = evt.ShowTime;
			Seats = evt.Seats;
		}
	}

	public class BookableShowCreated : IEvent
	{
		public Guid Id { get; private set; }
		public Guid ScreenId { get; private set; }
		public DateTime ShowTime { get; private set; }
		public List<BookableSeat> Seats{ get; private set; }

		public BookableShowCreated(Guid id, Guid screenId, DateTime showTime, List<BookableSeat> seats)
		{
			Id = id;
			ScreenId = screenId;
			ShowTime = showTime;
			Seats = seats;
		}
	}
}