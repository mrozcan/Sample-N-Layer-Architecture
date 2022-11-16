using App.Infrastructure.ORMs.EntityFramework.Abstract;
using App.Infrastructure.ORMs.EntityFramework.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.DependencyResolvers;
public class InfrastructureDI
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Inject Service and Manager
        services.AddTransient<ISampleRepository, SampleRepositoryDal>();
        services.AddSingleton<ISampleRepository, SampleRepositoryDal>();
    }
}
