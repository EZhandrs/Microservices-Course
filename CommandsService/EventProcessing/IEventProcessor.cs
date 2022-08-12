namespace CommandsService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessingEvent(string message);
    }
}
