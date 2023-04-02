// ------------------------------------------------------------
// <copyright file="ExceptionHandlerMiddlewareExtensions.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

namespace FinstarApi.Middleware;

/// <summary>
/// Extensions for ExceprionHandlerMiddleware.
/// </summary>
public static class ExceptionHandlerMiddlewareExtensions
{
    /// <summary>
    /// Use exception handler middleware.
    /// </summary>
    /// <param name="builder">IApplicationBuilder.</param>
    /// <returns>IApplicationBuilder with ExceprionHandlerMiddleware.</returns>
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
