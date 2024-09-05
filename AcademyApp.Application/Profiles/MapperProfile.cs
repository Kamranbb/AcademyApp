using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Extension;
using AcademyApp.Core.Entities;
using AutoMapper;

namespace AcademyApp.Application.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentCreateDto, Student>()
                .ForMember(d=>d.Image,map=>map.MapFrom(s=>s.File.Save(Directory.GetCurrentDirectory(),"uploads/images")));
        }
    }
}
