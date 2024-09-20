using AutoFixture;
using AutoMapper;
using EducaTesting.Application.Helper;
using EducaTesting.Domain;
using EducaTesting.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EducaTesting.Application.Courses
{
    [TestFixture]
    public class GetCourseQueryNUnitTests
    {
        private GetCourseQuery.GetCourseQueryHandler? handlerAllCourses;

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

            handlerAllCourses = new GetCourseQuery.GetCourseQueryHandler(educaTestingDbContextFake, mapperFake);
        }


        [Test]
        public async Task GetCourseQueryHandler_QueryCourses_ReturnsTrue()
        {
            // Act
            var request = new GetCourseQuery.GetCourseQueryRequest();

            // Arrange
            var result = await handlerAllCourses!.Handle(request, new System.Threading.CancellationToken());

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
