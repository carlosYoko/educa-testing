using AutoFixture;
using AutoMapper;
using EducaTesting.Application.Helper;
using EducaTesting.Domain;
using EducaTesting.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EducaTesting.Application.Courses
{
    [TestFixture]
    public class CreateCourseHandlerNUnitTests
    {
        private CreateCourseCommand.CreateCourseCommandHandler? handlerCreateCourse;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(x => x.CourseId, Guid.Empty)
                .Create()
                );

            var options = new DbContextOptionsBuilder<EducaTestingDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducaTestingDbContext-{Guid.NewGuid()}")
                .Options;

            var educaTestingDbContextFake = new EducaTestingDbContext(options);
            educaTestingDbContextFake.AddRange(courseRecords);
            educaTestingDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingTest());
            }
            );

            var mapperFake = mapConfig.CreateMapper();

            handlerCreateCourse = new CreateCourseCommand.CreateCourseCommandHandler(educaTestingDbContextFake);
        }

        [Test]
        public async Task CreateCourseCommandHandler_QueryCourses_ReturnsNumber()
        {
            // Act
            var request = new CreateCourseCommand.CreateCourseCommandRequest();
            request.DatePublication = DateTime.UtcNow.AddDays(12);
            request.Title = "Testing";
            request.Description = "Testing .NET";
            request.Price = 56;

            // Arrange
            var result = await handlerCreateCourse!.Handle(request, new System.Threading.CancellationToken());

            // Assert
            Assert.That(result, Is.EqualTo(Unit.Value));
        }

    }
}
