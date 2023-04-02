// ------------------------------------------------------------
// <copyright file="ITodoDbContext.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Finstar.Application.Interfaces;

/// <summary>
/// Todo database context.
/// </summary>
public interface ITodoDbContext
{
    /// <summary>
    /// Gets or sets todos.
    /// </summary>
    DbSet<Todo> Todos { get; set; }

    /// <summary>
    /// Gets or sets comments.
    /// </summary>
    DbSet<Commentary> Comments { get; set; }

    /// <summary>
    /// Save changes asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task of int.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
