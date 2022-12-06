using Api.Grpc.DependencyResolvers;
using Api.Grpc.Services;
using App.Infrastructure.DependencyResolvers;
using App.Logic.DependencyResolvers;

namespace Api.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();

        // Dependency Injections
        builder.Host.ConfigureServices(LogicDI.ConfigureServices);
        builder.Host.ConfigureServices(ApiGrpcDI.ConfigureServices);
        builder.Host.ConfigureServices(InfrastructureDI.ConfigureServices);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<SampleGrpcService>();

        app.MapGet("/", () => {} );

        app.Run();
    }
}
