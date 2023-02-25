using SchoolProject.Models;
namespace SchoolProject.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<Course> Courses { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

        public Course Course { get; set; }




    }
}



