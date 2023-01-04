using System.Net;
using Api.Grpc.DependencyResolvers;
using Api.Grpc.Services;
using App.Infrastructure.DependencyResolvers;
using App.Logic.DependencyResolvers;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Api.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();

        // Dependency Injections
        LogicDI.ConfigureServices(builder.Services);
        ApiGrpcDI.ConfigureServices(builder.Services);
        InfrastructureDI.ConfigureServices(builder.Services);

        // Use Kesterl as a server.
        builder.WebHost.UseKestrel();

        // configure Kestrel for Http 1, Http2 and Http 3
        builder.WebHost.ConfigureKestrel((contex, options) =>
            {
                options.Listen(IPAddress.Any, 5111, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    /*listenOptions.UseHttps(listenOptions =>
                    {
                        listenOptions.HandshakeTimeout = TimeSpan.FromSeconds(5);
                    });*/
                });
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<SampleGrpcService>();

        app.MapGet("/", () => { });

        app.Run();
    }
}
