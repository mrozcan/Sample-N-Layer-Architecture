using App.Logic.SampleLogic.Managers;
using App.Logic.SampleLogic.Services;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.Logic.DependencyResolvers;

public static class LogicDI
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Resolve Mapster        
        services.AddSingleton<IMapper, Mapper>();

        // Resolve Services and Managers
        services.AddSingleton<ISampleService, SampleManager>();

    }
}
