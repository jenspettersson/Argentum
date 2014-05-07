using System.Collections.Generic;

namespace Argentum.Core
{
    public class DirectBus : IBus
    {
        private readonly IProcessMessages _messageProcessor;
        private readonly object _lockObject = new object();
        private readonly Queue<object> _preCommitQueue;
        private readonly InMemoryQueue _postCommitQueue;

        public DirectBus(IProcessMessages messageProcessor)
        {
            _messageProcessor = messageProcessor;
            _preCommitQueue = new Queue<object>(32);
            _postCommitQueue = new InMemoryQueue();
            _postCommitQueue.Pop(DoProcess);
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

        public void Publish(object message)
        {
            lock (_lockObject)
            {
                _preCommitQueue.Enqueue(message);
            }
        }

        public void Publish(IEnumerable<object> messages)
        {
            lock (_lockObject)
            {
                foreach (var message in messages)
                {
                    _preCommitQueue.Enqueue(message);
                }
            }
        }

        private void DoProcess(object message)
        {
            dynamic processor = _messageProcessor;
            processor.Process((dynamic)message);
        }
    }
}