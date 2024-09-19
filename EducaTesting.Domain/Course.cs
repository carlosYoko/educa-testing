using System.ComponentModel.DataAnnotations;

namespace EducaTesting.Domain
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime? DatePublication { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCreation { get; set; }
        public decimal Price { get; set; }
    }
}
