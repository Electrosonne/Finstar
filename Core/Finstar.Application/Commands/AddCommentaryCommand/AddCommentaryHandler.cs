// ------------------------------------------------------------
// <copyright file="AddCommentaryHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.Interfaces;
using Finstar.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Finstar.Application.Commands;

/// <summary>
/// Handler of <see cref="AddCommentaryCommand"/>.
/// </summary>
public class AddCommentaryHandler : IRequestHandler<AddCommentaryCommand, bool>
{
    /// <summary>
    /// Todo database context.
    /// </summary>
    private readonly ITodoDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddCommentaryHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    public AddCommentaryHandler(ITodoDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Handle.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Id.</returns>
    public async Task<bool> Handle(AddCommentaryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var commentary = new Commentary()
            {
                Text = request.Text,
                TodoId = request.TodoId,
            };

            await this.context.Comments.AddAsync(commentary, cancellationToken);
            await this.context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
        catch
        {
            return false;
        }
    }
}