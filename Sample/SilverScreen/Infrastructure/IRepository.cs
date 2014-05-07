using System;
using System.IO;

namespace SilverScreen.Infrastructure
{
    public interface IRepository
    {
        TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate;
        void Save(IAggregate aggregate);
    }

    public class FileEventStore : IRepository
    {
        private string _path;

        public FileEventStore()
        {
            _path = @"c:\_store\silver\";
        }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate
        {
            throw new NotImplementedException();
        }

        public void Save(IAggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}