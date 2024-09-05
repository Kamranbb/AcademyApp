using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.Data.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Implementations
{
    public class StudentService(AcademyAppContext _appContext,IMapper _mapper) : IStudentService
    {

        public async Task<int> CreateAsync(StudentCreateDto studentCreateDto)
        {
            var existGroup = await _appContext.Groups
                .Include(g=>g.Students)
                .SingleOrDefaultAsync(g => g.Id == studentCreateDto.GroupId);
            if (existGroup is null)
                throw new EntityNotFoundException("group not found");
            if (existGroup.Limit <= existGroup.Students.Count())
                throw new LimitEntityException("Group limit is reached..");

            Student student = _mapper.Map<Student>(studentCreateDto);
            _appContext.Students.Add(student);
            await _appContext.SaveChangesAsync();
            return student.Id;
        }

        public List<Student> GetAll()
        {
            return _appContext.Students.ToList();
        }
    }
}
