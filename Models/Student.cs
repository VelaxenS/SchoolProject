using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
   
    public class Student
    {
        
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }



    }
}
