using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        [Key]
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }



    }
}
