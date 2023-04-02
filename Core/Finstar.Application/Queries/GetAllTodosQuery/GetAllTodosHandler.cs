// ------------------------------------------------------------
// <copyright file="GetAllTodosHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Finstar.Application.DTO;
using Finstar.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Finstar.Application.Queries;

/// <summary>
/// Handler of <see cref="GetAllTodosQuery"/>.
/// </summary>
public class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, IList>
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
    /// Initializes a new instance of the <see cref="GetAllTodosHandler"/> class.
    /// </summary>
    /// <param name="context">ITodoDbContext.</param>
    /// <param name="mapper">Mapper.</param>
    public GetAllTodosHandler(ITodoDbContext context, IMapper mapper)
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
    public async Task<IList> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        return await this.context.Todos
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Include(u => u.Comments)
            .ProjectTo<TodoDTO>(this.mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
