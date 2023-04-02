// ------------------------------------------------------------
// <copyright file="GetTodoQuery.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using Finstar.Application.DTO;
using MediatR;

namespace Finstar.Application.Queries;

/// <summary>
/// Query of getting todo.
/// </summary>
public class GetTodoQuery : IRequest<TodoDTO>
{
    /// <summary>
    /// Gets or sets todo id.
    /// </summary>
    public long TodoId { get; set; }
}
