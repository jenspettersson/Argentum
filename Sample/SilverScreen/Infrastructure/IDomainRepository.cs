using System;
using System.Collections.Generic;
using Argentum.Core;

namespace SilverScreen.Infrastructure
{
    public interface IDomainRepository
    {
        TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate;
        void Save(IAggregate aggregate);
    }

    public class DomainRepository : IDomainRepository
    {
        private readonly IEventStoreUnitOfWork _eventStoreUnitOfWork;

        public DomainRepository(IEventStoreUnitOfWork eventStoreUnitOfWork)
        {
            _eventStoreUnitOfWork = eventStoreUnitOfWork;
        }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate
        {
            throw new NotImplementedException();
        }

        public void Save(IAggregate aggregate)
        {
            _eventStoreUnitOfWork.Add(aggregate);
        }
    }

    public interface IEventStoreUnitOfWork : IUnitOfWork
    {
        TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate;
        void Add<TAggregate>(TAggregate aggregateRoot) where TAggregate : IAggregate;
    }

    public class EventStoreUnitOfWork : IEventStoreUnitOfWork
    {
        private readonly IDomainEventStorage _domainEventStorage;
        private readonly IBus _bus;
        private readonly List<IAggregate> _trackedAggregates;
        public EventStoreUnitOfWork(IDomainEventStorage domainEventStorage, IBus bus)
        {
            _domainEventStorage = domainEventStorage;
            _bus = bus;
            _trackedAggregates = new List<IAggregate>();
        }

        public void Commit()
        {
            foreach (var trackedAggregate in _trackedAggregates)
            {
                _domainEventStorage.Save(trackedAggregate);

                _bus.Publish(trackedAggregate.GetUncommittedEvents());
                trackedAggregate.Clear();
            }

            _bus.Commit();
        }

        public void Rollback()
        {
            _bus.Rollback();
            _trackedAggregates.Clear();
        }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregate
        {
            throw new NotImplementedException();
        }

        public void Add<TAggregate>(TAggregate aggregateRoot) where TAggregate : IAggregate
        {
            _trackedAggregates.Add(aggregateRoot);
        }
    }
}