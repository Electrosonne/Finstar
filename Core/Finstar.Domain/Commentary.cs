// ------------------------------------------------------------
// <copyright file="Commentary.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Finstar.Domain;

/// <summary>
/// Commentary entity.
/// </summary>
public class Commentary
{
    /// <summary>
    /// Gets or sets unique key id.
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets text of commentary.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets todo id.
    /// </summary>
    public long TodoId { get; set; }
}
