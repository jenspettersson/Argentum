using System;
using Argentum.Core;

namespace Argentum.Sample.Queries
{
    public class CurrentDateQueryHandler : IHandleQuery<GetCurrentDate, DateTime>
    {
        public DateTime HandleQuery(GetCurrentDate query)
        {
            return DateTime.Now;
        }
    }
}