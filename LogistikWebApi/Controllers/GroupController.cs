using Microsoft.AspNetCore.Mvc;
using LogistikWebApi.Models;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Dto;

namespace LogistikWebApi.Controllers;

[ApiController]

public class GroupController : Controller
{
    private readonly IGroupRepository _groupRepository;

    public GroupController(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    [HttpGet ("groups")]
    public async Task<ActionResult<List<GroupDto>>> HttpGetGroups()
    {
        return Ok(await _groupRepository.GetGroups());
    }

    [HttpGet("group")]
    public async Task<ActionResult<List<GroupDto>>> HttpGetGroupByName(string name)
    {
        var Group = _groupRepository.GetGroupByName(name);
        if (Group == null)
        {
            return BadRequest("Group Not found");
        }
        return Ok(await Group);
    }

    [HttpPost("group")]
    public async Task<ActionResult<List<GroupDto>>> HttpAddGroup(Group group) 
    {
        return Ok(await _groupRepository.AddGroup(group)); 
    }

    [HttpPut("group")]
    public async Task<ActionResult<List<GroupDto>>> HttpUpdateGroup(Group request) 
    {
        return Ok(await _groupRepository.UpdateGroup(request));
    }

    [HttpDelete("group")]
    public async Task<ActionResult<List<GroupDto>>> HttpDeleteGroup(Guid Id) 
    {
        return await _groupRepository.DeleteGroup(Id);
    }
}

