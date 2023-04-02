// ------------------------------------------------------------
// <copyright file="RemoveTodoCommand.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using MediatR;

namespace Finstar.Application.Commands;

/// <summary>
/// Remove todo command.
/// </summary>
public class RemoveTodoCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets todo id.
    /// </summary>
    public long TodoId { get; set; }
}
