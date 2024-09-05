using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Task<int> CreateAsync(StudentCreateDto studentCreateDto);
    }
}
