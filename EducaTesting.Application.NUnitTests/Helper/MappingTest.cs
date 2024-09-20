using AutoMapper;
using EducaTesting.Application.DTO;
using EducaTesting.Domain;

namespace EducaTesting.Application.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
