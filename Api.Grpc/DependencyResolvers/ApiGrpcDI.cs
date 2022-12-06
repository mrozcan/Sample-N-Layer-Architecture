using MapsterMapper;

namespace Api.Grpc.DependencyResolvers;

public static class ApiGrpcDI
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Resolve Mapster
        services.AddSingleton<IMapper, Mapper>();
    }

}
