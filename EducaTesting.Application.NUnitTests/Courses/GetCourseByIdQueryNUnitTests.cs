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
    internal class GetCourseByIdQueryNUnitTests
    {
        private GetCourseByIdQuery.GetCourseByIdQueryHandler? handlerByIdCourse;
        private Guid courseIdTest;

        [SetUp]
        public void SetUp()
        {
            courseIdTest = new Guid("032883d3-f018-4a70-80ec-0a48859a6a44");
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(x => x.CourseId, courseIdTest)
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

            handlerByIdCourse = new GetCourseByIdQuery.GetCourseByIdQueryHandler(educaTestingDbContextFake, mapperFake);
        }


        [Test]
        public async Task GetCourseByIdQueryHandler_InputCourseId_ReturnsNotNull()
        {
            // Act
            var request = new GetCourseByIdQuery.GetCourseByIdQueryRequest() { Id = courseIdTest };

            // Arrange
            var result = await handlerByIdCourse!.Handle(request, new System.Threading.CancellationToken());

            // Assert
            Assert.That(result, Is.Not.Null);
        }

    }
}
