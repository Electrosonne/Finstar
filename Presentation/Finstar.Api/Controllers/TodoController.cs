// ------------------------------------------------------------
// <copyright file="TodoController.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Finstar.Application.Commands;
using Finstar.Application.DTO;
using Finstar.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinstarApi.Controllers;

/// <summary>
/// Controller of ToDo.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    /// <summary>
    /// Mapper.
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// Mediator.
    /// </summary>
    private readonly IMediator mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    /// <param name="mapper">Mapper.</param>
    public TodoController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    /// <summary>
    /// Get all todos.
    /// </summary>
    /// <returns>Todo <see cref="TodoDTO"/>.</returns>
    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return this.Ok(await this.mediator.Send(new GetAllTodosQuery()));
    }

    /// <summary>
    /// Add new todos.
    /// </summary>
    /// <param name="addTodo">Add todo command.</param>
    /// <returns>Is successed flag.</returns>
    [HttpPost(Name = "Add")]
    public async Task<IActionResult> Add([FromBody] AddTodoCommand addTodo)
    {
        return this.Ok(new { IsSuccessed = await this.mediator.Send(addTodo) });
    }

    /// <summary>
    /// Get todo by id.
    /// </summary>
    /// <param name="id">Id of todo.</param>
    /// <returns>Todo <see cref="TodoDTO"/>.</returns>
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var query = new GetTodoQuery() { TodoId = id };
        var result = await this.mediator.Send(query);
        return this.Ok(new { IsSuccessed = result != null, Data = result });
    }

    /// <summary>
    /// Remove todo by id.
    /// </summary>
    /// <param name="removeTodo">Id of todo.</param>
    /// <returns>Is successed flag.</returns>
    [HttpDelete(Name = "Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveTodoCommand removeTodo)
    {
        return this.Ok(new { IsSuccessed = await this.mediator.Send(removeTodo) });
    }

    /// <summary>
    /// Update todo.
    /// </summary>
    /// <param name="updateTodo">Todo updated model.</param>
    /// <returns>Is successed flag.</returns>
    [HttpPut(Name = "Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTodoCommand updateTodo)
    {
        return this.Ok(new { IsSuccessed = await this.mediator.Send(updateTodo) });
    }

    /// <summary>
    /// Get all comments for todo.
    /// </summary>
    /// <param name="id">Id of todo.</param>
    /// <returns>List of <see cref="CommentaryDTO"/>.</returns>
    [HttpGet("GetComments/{id}")]
    public async Task<IActionResult> GetComments([FromRoute] int id)
    {
        var query = new GetTodoQuery() { TodoId = id };
        var result = await this.mediator.Send(query);

        return this.Ok(new { IsSuccessed = result != null, Data = result?.Comments });
    }

    /// <summary>
    /// Add comment to todo.
    /// </summary>
    /// <param name="addCommentary">Commentary data.</param>
    /// <returns>Is successed flag.</returns>
    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment([FromBody] AddCommentaryCommand addCommentary)
    {
        return this.Ok(new { IsSuccessed = await this.mediator.Send(addCommentary) });
    }
}