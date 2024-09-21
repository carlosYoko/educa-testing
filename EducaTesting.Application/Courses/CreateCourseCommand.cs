using EducaTesting.Domain;
using EducaTesting.Persistence;
using FluentValidation;
using MediatR;

namespace EducaTesting.Application.Courses
{
    public class CreateCourseCommand
    {
        public class CreateCourseCommandRequest : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime DatePublication { get; set; }
            public decimal Price { get; set; }
        }

        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Title);
            }
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest>
        {
            private readonly EducaTestingDbContext _context;

            public CreateCourseCommandHandler(EducaTestingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    DateCreation = DateTime.UtcNow,
                    DatePublication = request.DatePublication,
                    Price = request.Price
                };

                _context.Add(course);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se ha podido añadir el curso");
            }
        }
    }
}
