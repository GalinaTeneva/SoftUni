using System.ComponentModel.DataAnnotations;

using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    public Course()
    {
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();

        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int CourseId { get; set; }

    [MaxLength(ValidationConstants.CourseNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}
