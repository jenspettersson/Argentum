using System;
using Argentum.Core;

namespace Argentum.Sample
{
    class Program
    {
        static void Main()
        {
            var messageBus = Core.Argentum.Initialize();

            messageBus.Process(new PublishMessage("Hello Argentum!"));

            var dateTime = messageBus.Process(new GetCurrentDate());

            Console.WriteLine("This is what I got: {0}!", dateTime);

            Console.ReadLine();
        }
    }

    public class GetCurrentDate : IQuery<DateTime> { }

    public class CurrentDateQueryHandler : IHandleQuery<GetCurrentDate, DateTime>
    {
        public DateTime HandleQuery(GetCurrentDate query)
        {
            return DateTime.Now;
        }
    }

    public class PublishMessage : ICommand
    {
        public string Message { get; set; }

        public PublishMessage(string message)
        {
            Message = message;
        }
    }

    public class PublishMessageHandler : IHandleCommand<PublishMessage>
    {
        public void HandleCommand(PublishMessage command)
        {
            Console.WriteLine(command.Message);
        }
    }
}
