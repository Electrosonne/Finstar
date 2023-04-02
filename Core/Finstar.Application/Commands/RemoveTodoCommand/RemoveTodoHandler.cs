// ------------------------------------------------------------
// <copyright file="RemoveTodoHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Finstar.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finstar.Application.Commands;

/// <summary>
/// Handler of <see cref="RemoveTodoCommand"/>
/// </summary>
public class RemoveTodoHandler : IRequestHandler<RemoveTodoCommand, bool>
{
    /// <summary>
    /// Todo database context.
    /// </summary>
    private readonly ITodoDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTodoHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    public RemoveTodoHandler(ITodoDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Handle.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Id.</returns>
    public async Task<bool> Handle(RemoveTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todo = new Todo() { Id = request.TodoId };

            this.context.Todos.Attach(todo);
            this.context.Todos.Remove(todo);
            await this.context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
        catch
        {
            return false;
        }
    }
}
