using AutoMapper;
using EducaTesting.Application.DTO;
using EducaTesting.Domain;
using EducaTesting.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducaTesting.Application.Courses
{
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDTO>
        {
            public Guid Id;
        }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDTO>
        {
            private readonly EducaTestingDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseByIdQueryHandler(EducaTestingDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CourseDTO> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
                var courseDTO = _mapper.Map<Course, CourseDTO>(course);
                return courseDTO;
            }
        }
    }
}
