using Argentum.Core;

namespace Argentum.Sample.Commands
{
    public class PublishMessage : ICommand
    {
        public string Message { get; set; }

        public PublishMessage(string message)
        {
            Message = message;
        }
    }

    public class RunPerformance : ICommand { }

    public class RunPerformanceHandler : IHandleCommand<RunPerformance>
    {
        public void HandleCommand(RunPerformance command)
        {
            
        }
    }
}