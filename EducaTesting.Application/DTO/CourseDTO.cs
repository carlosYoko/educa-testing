namespace EducaTesting.Application.DTO
{
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DatePublication { get; set; }
        public decimal Price { get; set; }
    }
}
