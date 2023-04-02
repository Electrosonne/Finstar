// ------------------------------------------------------------
// <copyright file="AddCommentaryCommand.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using MediatR;

namespace Finstar.Application.Commands;

/// <summary>
/// Add commentary command.
/// </summary>
public class AddCommentaryCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets todo id.
    /// </summary>
    public long TodoId { get; set; }

    /// <summary>
    /// Gets or sets text.
    /// </summary>
    public string Text { get; set; }
}
