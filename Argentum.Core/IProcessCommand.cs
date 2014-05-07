using System;
using System.Collections.Generic;
using TinyIoC;

namespace Argentum.Core
{
    public interface IProcessCommand : IUnitOfWork
    {
        void Process(ICommand command);
    }

    public class DirectBus : IProcessCommand
    {
        private readonly object _lockObject = new object();
        private readonly Queue<ICommand> _preCommitQueue;
        private readonly InMemoryQueue _postCommitQueue;

        public DirectBus()
        {
            _preCommitQueue = new Queue<ICommand>(32);
            _postCommitQueue = new InMemoryQueue();
            _postCommitQueue.Pop(DoPublish);
        }

        public void Commit()
        {
            lock (_lockObject)
            {
                while (_preCommitQueue.Count > 0)
                {
                    _postCommitQueue.Put(_preCommitQueue.Dequeue());
                }
            }
        }

        public void Rollback()
        {
            lock (_lockObject)
            {
                _preCommitQueue.Clear();
            }
        }

        public void Process(ICommand command)
        {
            lock (_lockObject)
            {
                _preCommitQueue.Enqueue(command);
            }
        }

        private void DoPublish(object command)
        {
            try
            {
                Type handlerType = typeof(IHandleCommand<>).MakeGenericType(command.GetType());

                dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);

                handler.HandleCommand((dynamic)command);
            }
            finally
            {
                _postCommitQueue.Pop(DoPublish);
            }
        }
    }
}