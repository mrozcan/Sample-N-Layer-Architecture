using App.Core.Configurations.Abstract;
using App.Core.Configurations.Concrete;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App.Core.DependencyResolvers;

public class CoreDI
{
    public static void ConfigureServices(IServiceCollection services)
    {

        // Inject Service and Manager
        // Mediator Configuraiton
        //var mediatorConf = new MediatRServiceConfiguration();
        //services.AddMediatR(mediatorConf);

        // Add configuration after use mongo
        services.AddSingleton<IMongoConfig>
            (service => service.GetRequiredService<IOptions<MongoConfig>>().Value);

    }
}
