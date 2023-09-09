using App.Core.Configurations.Concrete;
using App.Core.DependencyResolvers;
using App.Infrastructure.DependencyResolvers;
using App.Logic.DependencyResolvers;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Dependency Injections
        CoreDI.ConfigureServices(builder.Services);
        LogicDI.ConfigureServices(builder.Services);
        InfrastructureDI.ConfigureServices(builder.Services);

        // Add appsettings.json configurations
        builder.Services.Configure<MongoConfig>
            (builder.Configuration.GetSection("MongoConfig"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(conf => {
                conf.SwaggerEndpoint("/swagger/v1/swagger.json","Sample Api v1");
                conf.RoutePrefix = string.Empty;
            });
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
