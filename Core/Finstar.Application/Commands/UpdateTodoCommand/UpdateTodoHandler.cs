// ------------------------------------------------------------
// <copyright file="UpdateTodoHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Finstar.Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Finstar.Application.Commands;

/// <summary>
/// Handler of <see cref="UpdateTodoCommand"/>.
/// </summary>
public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, bool>
{
    /// <summary>
    /// Todo database context.
    /// </summary>
    private readonly ITodoDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTodoHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    public UpdateTodoHandler(ITodoDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Handle.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Id.</returns>
    public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todo = new Todo
            {
                Id = request.TodoId,
                Title = request.Title,
                IsClosed = request.IsClosed,
                Category = request.Category,
                Color = request.Color,
            };

            this.context.Todos.Attach(todo);

            this.context.Todos.Entry(todo).Property(x => x.Title).IsModified = true;
            this.context.Todos.Entry(todo).Property(x => x.IsClosed).IsModified = true;
            this.context.Todos.Entry(todo).Property(x => x.Category).IsModified = true;
            this.context.Todos.Entry(todo).Property(x => x.Color).IsModified = true;

            await this.context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
        catch
        {
            return false;
        }
    }
}
