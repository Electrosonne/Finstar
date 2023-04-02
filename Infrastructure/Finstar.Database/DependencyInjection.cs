// ------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finstar.Database;

/// <summary>
/// DI.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// AddApplication.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <param name="configuration">Configuration.</param>
    /// <returns>Services with MediatR.</returns>
    public static IServiceCollection AddDatabase(
       this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FinstarDb");
        services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<ITodoDbContext>(provider =>
        {
            return provider.GetRequiredService<TodoDbContext>();
        });
        return services;
    }
}
