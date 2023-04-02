// ------------------------------------------------------------
// <copyright file="AddTodoValidator.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;

namespace Finstar.Application.Commands;

/// <summary>
/// Validation of <see cref="AddTodoCommand"/>.
/// </summary>
public class AddTodoValidator : AbstractValidator<AddTodoCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddTodoValidator"/> class.
    /// </summary>
    public AddTodoValidator()
    {
        this.RuleFor(todo => todo.Title).NotEmpty().WithMessage("Title must not be empty");
    }
}
