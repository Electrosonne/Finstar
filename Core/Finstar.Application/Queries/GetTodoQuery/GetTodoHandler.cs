// ------------------------------------------------------------
// <copyright file="GetTodoHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Finstar.Application.DTO;
using Finstar.Application.Interfaces;
using Finstar.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finstar.Application.Queries;

/// <summary>
/// Handler of <see cref="GetTodoQuery"/>.
/// </summary>
public class GetTodoHandler : IRequestHandler<GetTodoQuery, TodoDTO>
{
    /// <summary>
    /// Todo database context.
    /// </summary>
    private readonly ITodoDbContext context;

    /// <summary>
    /// Mapper.
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTodoHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    /// <param name="mapper">Mapper.</param>
    public GetTodoHandler(ITodoDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <summary>
    /// Handle.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Id.</returns>
    public async Task<TodoDTO> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await this.context.Todos
            .AsNoTracking()
            .Where(todo => todo.Id == request.TodoId)
            .Include(u => u.Comments)
            .SingleOrDefaultAsync(cancellationToken);

        return this.mapper.Map<TodoDTO>(todo);
    }
}
