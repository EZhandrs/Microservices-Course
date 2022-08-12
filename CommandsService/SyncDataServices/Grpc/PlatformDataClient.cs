using AutoMapper;
using Grpc.Net.Client;

using CommandsService.Models;
using PlatformService;

namespace CommandsService.SyncDataServices.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlatformDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Platform> ReturnAllPlatforms()
        {
            var address = _configuration["GrpcPlatform"];

            Console.WriteLine($"--> Calling Grpc Service {address}");

            var channel = GrpcChannel.ForAddress(address);
            var client = new GrpcPlatform.GrpcPlatformClient(channel);
            var request = new GetAllRequest();

            try
            {
                var repy = client.GetAllPlatforms(request);
                return _mapper.Map<IEnumerable<Platform>>(repy.Platform);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not call Grpc Server {ex.Message}");
                return null;
            }
        }
    }
}