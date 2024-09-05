using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Implementations
{
    public class GroupService(AcademyAppContext _appContext) : IGroupService
    {

        public async Task<int> CreateAsync(GroupCreateDto groupCreateDto)
        {
            if (await _appContext.Groups.AnyAsync(g=>g.Name.ToLower()==groupCreateDto.Name.ToLower()))
                throw new DuplicateEntityException("duplicate entity...");
            Group group = new();
            group.Name=groupCreateDto.Name;
            group.Limit=groupCreateDto.Limit;
            _appContext.Groups.Add(group);
            await _appContext.SaveChangesAsync();
            return group.Id;
        }

        public List<Group> GetAll()
        {
            return _appContext.Groups.ToList();
        }
    }
}
