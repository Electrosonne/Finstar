// ------------------------------------------------------------
// <copyright file="RemoveTodoValidator.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;

namespace Finstar.Application.Commands;

/// <summary>
/// Remove todo validator.
/// </summary>
public class RemoveTodoValidator : AbstractValidator<RemoveTodoCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTodoValidator"/> class.
    /// </summary>
    public RemoveTodoValidator()
    {
        this.RuleFor(todo => todo.TodoId).NotEmpty().WithMessage("Todo id must not be empty");
    }
}
