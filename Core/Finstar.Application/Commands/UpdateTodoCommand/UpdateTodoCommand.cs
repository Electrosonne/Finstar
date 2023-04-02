// ------------------------------------------------------------
// <copyright file="UpdateTodoCommand.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Finstar.Application.Commands;

/// <summary>
/// Update todo command.
/// </summary>
public class UpdateTodoCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets todo id.
    /// </summary>
    public long TodoId { get; set; }

    /// <summary>
    /// Gets or sets title description.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether is closed.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public Categories Category { get; set; }

    /// <summary>
    /// Gets or sets color.
    /// </summary>
    public Colors Color { get; set; }
}
