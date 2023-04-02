// ------------------------------------------------------------
// <copyright file="CommentaryDTO.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Finstar.Application.Mapping;
using Finstar.Domain;

namespace Finstar.Application.DTO;

/// <summary>
/// DTO commentary entity.
/// </summary>
public class CommentaryDTO : IMapWith<Commentary>
{
    /// <summary>
    /// Gets or sets text of commentary.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Mapping.
    /// </summary>
    /// <param name="profile">Profile.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Commentary, CommentaryDTO>()
            .ForMember(
                dto => dto.Text,
                opt => opt.MapFrom(commentary => commentary.Text));
    }
}
