using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace LogistikWebApi.Dto;

public class GroupDto
{
    public static GroupDto FromGroup(Group group) 
    {
        var groupDto = new GroupDto() 
        {
            Id = group.Id,
            Name = group.Name,
            ValueAddedTaxes = group.ValueAddedTaxes,
        };
        return groupDto;
    }

    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    public int ValueAddedTaxes { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}
