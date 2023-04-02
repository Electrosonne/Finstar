// ------------------------------------------------------------
// <copyright file="UpdateTodoValidator.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;

namespace Finstar.Application.Commands;

/// <summary>
/// Update todo validator.
/// </summary>
public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTodoValidator"/> class.
    /// </summary>
    public UpdateTodoValidator()
    {
        this.RuleFor(todo => todo.TodoId).NotEmpty().WithMessage("Todo id must not be empty");
        this.RuleFor(todo => todo.Title).NotEmpty().WithMessage("Title must not be empty");
    }
}
