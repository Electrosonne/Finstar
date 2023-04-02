// ------------------------------------------------------------
// <copyright file="Todo.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Finstar.Domain;

/// <summary>
/// Todo entity.
/// </summary>
public class Todo
{
    /// <summary>
    /// Gets or sets unique key id.
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets title description.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets date of creation.
    /// </summary>
    [Required]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether is closed.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public Categories Category { get; set; }

    /// <summary>
    /// Gets or sets color.
    /// </summary>
    public Colors Color { get; set; }

    /// <summary>
    /// Gets or sets comments.
    /// </summary>
    public IList<Commentary> Comments { get; set; }
}
