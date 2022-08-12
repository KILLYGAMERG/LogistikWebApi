using LogistikWebApi.Data;
using LogistikWebApi.Dto;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikWebApi.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly DataContext _context;

    public GroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<List<GroupDto>>> AddGroup(Group group)
    {
        _context.Groups.Add(group);
        await Save();
        return await GetGroups();

    }

    public async Task<ActionResult<List<GroupDto>>> DeleteGroup(Guid id)
    {

        var Group = await _context.Groups.FindAsync(id);
        if (Group == null) 
        {
            throw new Exception();
        }
        _context.Groups.Remove(Group);
        await Save();
        return await GetGroups();
    }

    public async Task<ActionResult<Group>> GetGroupByName(string name)
    {
        var myGroup = await _context.Groups.FirstAsync(g => g.Name == name);
        if (myGroup == null) 
        {
            throw new Exception();
        }

        return myGroup;
    }

    public async Task<ActionResult<List<GroupDto>>> GetGroups()
    {
        return await _context.Groups.Select(x => GroupDto.FromGroup(x)).ToListAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ActionResult<List<GroupDto>>> UpdateGroup(Group request)
    {
        var Group = await _context.Groups.FindAsync(request.Id);
        if (Group == null) 
        {
            throw new Exception();
        }
        Group.Name = request.Name; 
        Group.ValueAddedTaxes = request.ValueAddedTaxes;

        await Save();

        return await GetGroups();
    }


}

