using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces
{
    public interface IGroupService
    {
        List<Group> GetAll();
        Task<int> CreateAsync(GroupCreateDto groupCreateDto);
    }
}
