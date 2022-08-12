using PlatformService.Dtos;

namespace PlatformService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishePlatform(PlatformPublishedDto platformPublishedDto);
    }
}