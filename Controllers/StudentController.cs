using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Data;
using Microsoft.EntityFrameworkCore;
using SchoolProject.ViewModels;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;

            

        public StudentController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age")] Student student)
        {

            if (student.Name == null)
            {
                ViewBag.failMessage = "Öğrenci ismi boş bırakılamaz!";
                return View();
            }
            else if (student.Surname == null)
            {
                ViewBag.failMessage = "Öğrenci Soyadı boş bırakılamaz!";
                return View();
            }
            else if (student.Age == null)
            {
                ViewBag.failMessage = "Öğrenci yaşı boş bırakılamaz!";
                return View();
            }
            else
            {
                _context.Student.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConf(int id)
        {
            ViewBag.succMessage = "Öğrenci Başarıyla Silindi.";
            var student = await _context.Student.FirstOrDefaultAsync(m => m.StudentID == id);
            _context.Student.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            
            var student = await _context.Student.FirstOrDefaultAsync(m => m.StudentID == id);
            var course = await _context.Course.ToListAsync();
            var enrollments = from c in _context.Enrollments
                              select c;
            enrollments = enrollments.Where(s => s.StudentID == student.StudentID);

            

            StudentViewModel svm = new StudentViewModel()
            {
                Student = student,
                Courses = course,
                Enrollments = enrollments
            };
            return View(svm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int StudentID, int CourseID, [Bind("CourseID, StudentID, Grade")] Enrollment enrollment)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }
        
        
    }
}
