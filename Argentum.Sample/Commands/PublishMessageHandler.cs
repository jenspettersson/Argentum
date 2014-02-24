using System;
using Argentum.Core;

namespace Argentum.Sample.Commands
{
    public class PublishMessageHandler : IHandleCommand<PublishMessage>
    {
        public void HandleCommand(PublishMessage command)
        {
            Console.WriteLine(command.Message);
        }
    }
}