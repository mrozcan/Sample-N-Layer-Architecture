using Api.Grpc.DependencyResolvers;
using Api.Grpc.Services;
using App.Core.Configurations.Concrete;
using App.Core.DependencyResolvers;
using App.Infrastructure.DependencyResolvers;
using App.Logic.DependencyResolvers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace Api.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();

        // Dependency Injections
        CoreDI.ConfigureServices(builder.Services);
        LogicDI.ConfigureServices(builder.Services);
        ApiGrpcDI.ConfigureServices(builder.Services);
        InfrastructureDI.ConfigureServices(builder.Services);

        // Add appsettings.json configurations
        builder.Services.Configure<MongoConfig>
            (builder.Configuration.GetSection("MongoConfig"));

        // Use Kesterl as a server.
        builder.WebHost.UseKestrel();

        // configure Kestrel for Http 1, Http2 and Http 3
        builder.WebHost.ConfigureKestrel((contex, options) =>
            {
                options.Listen(IPAddress.Any, 5111, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    listenOptions.UseHttps(listenOptions =>
                    {
                        listenOptions.HandshakeTimeout = TimeSpan.FromSeconds(5);
                    });
                });
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<SampleGrpcService>();

        app.MapGet("/", () => { });

        app.Run();
    }
}
