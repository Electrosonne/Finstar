// ------------------------------------------------------------
// <copyright file="TodoDbContext.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Finstar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Finstar.Database;

/// <summary>
/// Todo database context implementation.
/// </summary>
public class TodoDbContext : DbContext, ITodoDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoDbContext"/> class.
    /// </summary>
    /// <param name="options">Options.</param>
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
    {
        this.Database.EnsureCreated();
    }

    /// <summary>
    /// Gets or sets todos table.
    /// </summary>
    public DbSet<Todo> Todos { get; set; }

    /// <summary>
    /// Gets or sets comments table.
    /// </summary>
    public DbSet<Commentary> Comments { get; set; }

    /// <inheritdoc/>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasMany(t => t.Comments)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Todo>()
            .HasIndex(t => new { t.Title, t.Category })
            .IsUnique(true);

        modelBuilder.Entity<Todo>().HasData(new Todo[]
        {
                new Todo
                {
                    Id = 1,
                    Title = "Create a ticket",
                    IsClosed = false,
                    CreatedDate = DateTime.Now,
                    Category = Categories.Analytics,
                    Color = Colors.Red,
                },
                new Todo
                {
                    Id = 2,
                    IsClosed = false,
                    CreatedDate = DateTime.Now,
                    Title = "Request information ",
                    Category = Categories.Bookkeeping,
                    Color = Colors.Green,
                },
        });

        modelBuilder.Entity<Commentary>().HasData(new Commentary[]
        {
            new Commentary
            {
                Id = 1,
                Text = "First",
                TodoId = 1,
            },
            new Commentary
            {
                Id = 2,
                Text = "Second",
                TodoId = 1,
            },
        });
    }
}
