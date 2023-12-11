namespace Microsoft.AspNetCore.Builder;

using Inspirer.Api.Util.Mapper;
using Inspirer.Business.Util.Services;
using Inspirer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


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
            typeof(Program).Assembly
            // InspirerBusinessAssembly.GetAssembly() TODO: Use business assembly after refactoring
        ));

        // Custom Services
        services.AddTransient<IThereGameDataService, ThereGameDbContext>();

        return services;
    }
}