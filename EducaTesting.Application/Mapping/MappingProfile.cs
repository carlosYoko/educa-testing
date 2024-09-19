using AutoMapper;
using EducaTesting.Application.DTO;
using EducaTesting.Domain;

namespace EducaTesting.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
