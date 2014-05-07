using System.IO;
using Newtonsoft.Json;

namespace SilverScreen.Infrastructure
{
    public interface IDomainEventStorage
    {
        void Save(IAggregate aggregate);
    }

    public class DiskDomainEventStorage : IDomainEventStorage
    {
        private readonly string _path;

        public DiskDomainEventStorage()
        {
            _path = @"c:\temp\storage\";
        }

        public void Save(IAggregate aggregate)
        {
            //Open file stream
            var aggregateName = aggregate.GetType().Name;

            string aggregateFileName = string.Format("{0}-{1}.evt", aggregateName, aggregate.Id);

            var pathToFile = Path.Combine(_path, aggregateFileName);

            var uncommittedEvents = aggregate.GetUncommittedEvents();
            foreach (var uncommittedEvent in uncommittedEvents)
            {
                var serializeObject = JsonConvert.SerializeObject(uncommittedEvent);
                File.AppendAllText(pathToFile, serializeObject);
            }
        }
    }
}