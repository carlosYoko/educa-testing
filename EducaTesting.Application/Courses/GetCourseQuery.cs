using EducaTesting.Domain;
using EducaTesting.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducaTesting.Application.Courses
{
    public class GetCourseQuery
    {
        public class GetCourseQueryRequest : IRequest<List<Course>> { }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<Course>>
        {
            private readonly EducaTestingDbContext _context;

            public GetCourseQueryHandler(EducaTestingDbContext context)
            {
                _context = context;
            }

            public async Task<List<Course>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.ToListAsync();

                return courses;
            }
        }
    }
}
