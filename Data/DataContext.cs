using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;


namespace SchoolProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; } 
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

    }
}
