// ------------------------------------------------------------
// <copyright file="GetAllTodosQuery.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using MediatR;
using System.Collections;

namespace Finstar.Application.Queries;

/// <summary>
/// Query of getting all todos.
/// </summary>
public class GetAllTodosQuery : IRequest<IList>
{
}
