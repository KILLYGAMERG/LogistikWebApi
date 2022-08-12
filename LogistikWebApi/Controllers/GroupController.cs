using Microsoft.AspNetCore.Mvc;
using LogistikWebApi.Models;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Dto;

namespace LogistikWebApi.Controllers;

[ApiController, Route ("[controller]")]

public class GroupController : Controller
{
    private readonly IGroupRepository _groupRepository;

    public GroupController(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<GroupDto>>> HttpGetGroups()
    {
        return Ok(await _groupRepository.GetGroups());
    }

    //[HttpGet]
    //public async Task<ActionResult<List<GroupDto>>> HttpGetGroupByName(string name)
    //{
    //    var Group = _groupRepository.GetGroupByName(name);
    //    if (Group == null) 
    //    {
    //        return BadRequest("Group Not found");
    //    }
    //    return Ok(await Group);
    //}

    [HttpPost]
    public async Task<ActionResult<List<GroupDto>>> HttpAddGroup(Group group) 
    {
        return Ok(await _groupRepository.AddGroup(group)); 
    }

    [HttpPut]
    public async Task<ActionResult<List<GroupDto>>> HttpUpdateGroup(Group request) 
    {
        return Ok(await _groupRepository.UpdateGroup(request));
    }

    [HttpDelete]
    public async Task<ActionResult<List<GroupDto>>> HttpDeleteGroup(Guid Id) 
    {
        return await _groupRepository.DeleteGroup(Id);
    }
}

