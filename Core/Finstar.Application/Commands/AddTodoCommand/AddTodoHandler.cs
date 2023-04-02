// ------------------------------------------------------------
// <copyright file="AddTodoHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Finstar.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finstar.Application.Commands;

/// <summary>
/// Handler of <see cref="AddTodoCommand"/>.
/// </summary>
public class AddTodoHandler : IRequestHandler<AddTodoCommand, bool>
{
    /// <summary>
    /// Todo database context.
    /// </summary>
    private readonly ITodoDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddTodoHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    public AddTodoHandler(ITodoDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Handle.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Id.</returns>
    public async Task<bool> Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todo = new Todo()
            {
                Title = request.Title,
                CreatedDate = DateTime.Now,
                IsClosed = false,
                Category = request.Category,
                Color = request.Color,
                Comments = null,
            };

            await this.context.Todos.AddAsync(todo, cancellationToken);
            await this.context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
        catch
        {
            return false;
        }
    }
}
