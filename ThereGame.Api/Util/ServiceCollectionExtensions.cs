namespace Microsoft.AspNetCore.Builder;

using ThereGame.Api.Util.Mapper;
using ThereGame.Business.Util.Services;
using ThereGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Util;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddThereGame(this IServiceCollection services, ConfigurationManager configuration)
    {
        // DB
        services.AddDbContextPool<ThereGameDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Dev"))
        );

        // Mapper
        services.AddAutoMapper(typeof(ThereGameMappingProfile));

        // MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(Program).Assembly,
            ThereGameBusinessAssembly.GetAssembly()
        ));

        // Custom Services
        services.AddTransient<IThereGameDataService, ThereGameDbContext>();
        services.AddTransient<ISpeechTextGeneratorService, SpeechTextGeneratorService>();

        // Cors
        services.AddCors(options => options.AddPolicy("corspolicy",
                       builder =>
                       {
                            builder.AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithOrigins("*")
                                .AllowAnyMethod();
                       }));

        return services;
    }
}