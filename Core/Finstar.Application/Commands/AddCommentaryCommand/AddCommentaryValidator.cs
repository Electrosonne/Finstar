// ------------------------------------------------------------
// <copyright file="AddCommentaryValidator.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;

namespace Finstar.Application.Commands;

/// <summary>
/// Add commentary validator.
/// </summary>
public class AddCommentaryValidator : AbstractValidator<AddCommentaryCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddCommentaryValidator"/> class.
    /// </summary>
    public AddCommentaryValidator()
    {
        this.RuleFor(todo => todo.Text).NotEmpty().WithMessage("Text must not be empty");
    }
}
