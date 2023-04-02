// ------------------------------------------------------------
// <copyright file="TodoDTO.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2023.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Finstar.Application.Mapping;
using Finstar.Domain;
using System.Security.Cryptography;
using System.Text;

namespace Finstar.Application.DTO;

/// <summary>
/// DTO todo entity.
/// </summary>
public class TodoDTO : IMapWith<Todo>
{
    /// <summary>
    /// Gets or sets hash.
    /// </summary>
    private string hash;

    /// <summary>
    /// Gets or sets unique key id.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets title description.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets date of creation.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether is closed.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets color.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets comments.
    /// </summary>
    public CommentaryDTO[] Comments { get; set; }

    /// <summary>
    /// Gets hash.
    /// </summary>
    public string Hash => this.hash ?? this.InitHashMd5();

    /// <summary>
    /// Mapping.
    /// </summary>
    /// <param name="profile">Profile.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Todo, TodoDTO>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(todo => todo.Id))
            .ForMember(
                dto => dto.Title,
                opt => opt.MapFrom(todo => todo.Title))
            .ForMember(
                dto => dto.CreatedDate,
                opt => opt.MapFrom(todo => todo.CreatedDate))
            .ForMember(
                dto => dto.IsClosed,
                opt => opt.MapFrom(todo => todo.IsClosed))
            .ForMember(
                dto => dto.Category,
                opt => opt.MapFrom(todo => todo.Category))
            .ForMember(
                dto => dto.Color,
                opt => opt.MapFrom(todo => todo.Color))
            .ForMember(
                dto => dto.Comments,
                opt => opt.MapFrom(todo => todo.Comments));
    }

    /// <summary>
    /// Initializing md5 for hash field.
    /// </summary>
    /// <returns>Hash.</returns>
    private string InitHashMd5()
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(this.Title));

            this.hash = Convert.ToHexString(hashBytes);
        }

        return this.hash;
    }
}
