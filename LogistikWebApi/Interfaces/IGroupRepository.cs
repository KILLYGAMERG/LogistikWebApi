using LogistikWebApi.Dto;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogistikWebApi.Interfaces;

public interface IGroupRepository
{
    public Task<ActionResult<List<GroupDto>>> GetGroups();
    public Task<ActionResult<Group>> GetGroupByName(string name);
    public Task<ActionResult<List<GroupDto>>> AddGroup(Group group);
    public Task Save();
    public Task<ActionResult<List<GroupDto>>> UpdateGroup(Group request);
    public Task<ActionResult<List<GroupDto>>> DeleteGroup(Guid id);
}

