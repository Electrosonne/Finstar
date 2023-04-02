// ------------------------------------------------------------
// <copyright file="AddTodoCommand.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Domain;
using MediatR;

namespace Finstar.Application.Commands;

/// <summary>
/// Add todo command.
/// </summary>
public class AddTodoCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets title description.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public Categories Category { get; set; }

    /// <summary>
    /// Gets or sets color.
    /// </summary>
    public Colors Color { get; set; }
}
