using AutoFixture;
using EducaTesting.Domain;
using EducaTesting.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EducaTesting.Application.Courses
{
    [TestFixture]
    public class GetCourseQueryNUnitTests
    {
        private GetCourseQuery.GetCourseQueryHandler handlerAllCourses;

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

            var educaTestingDbContext = new EducaTestingDbContext(options);
            educaTestingDbContext.AddRange(courseRecords);
            educaTestingDbContext.SaveChanges();

        }


        [Test]
        public void GetCourseQueryHandler_QueryCourses_ReturnsTrue()
        {
            // Act

            // Arrange

            // Assert
        }
    }
}
