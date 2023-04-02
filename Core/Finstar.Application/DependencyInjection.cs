// ------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finstar.Application;

/// <summary>
/// DI.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// AddApplication.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <returns>Services with MediatR.</returns>
    public static IServiceCollection AddApplication(
       this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
