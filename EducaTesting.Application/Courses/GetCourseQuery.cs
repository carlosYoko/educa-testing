using AutoMapper;
using EducaTesting.Application.DTO;
using EducaTesting.Domain;
using EducaTesting.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducaTesting.Application.Courses
{
    public class GetCourseQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDTO>> { }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDTO>>
        {
            private readonly EducaTestingDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseQueryHandler(EducaTestingDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CourseDTO>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.ToListAsync();
                var courseDTO = _mapper.Map<List<Course>, List<CourseDTO>>(courses);
                return courseDTO;
            }
        }
    }
}
