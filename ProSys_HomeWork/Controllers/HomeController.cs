using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProSys_HomeWork.Data;
using ProSys_HomeWork.Data.Model;
using ProSys_HomeWork.Models;
using ProSys_HomeWork.Models.Enums;

namespace ProSys_HomeWork.Controllers;

public class HomeController(SchoolDbContext context) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterLesson([FromBody] LessonViewModel lesson)
    {
        
        if (!ModelState.IsValid)
        {
            return Json(new BaseResponseModel
            {
               Type = NotificationType.InvalidModel
            });
        }

        if (await context.Lessons.AnyAsync(x=>x.LessonCode.Equals(lesson.LessonCode)))
        {
            return Json(new BaseResponseModel
            {
                Type = NotificationType.Error,
                Message = "Bu ders kodu sistemdə mövcuddur"
            });
        }
        
        try
        {
            await context.Lessons.AddAsync(new Lesson
            {
                LessonCode = lesson.LessonCode,
                LessonName = lesson.LessonName,
                ClassNumber = lesson.ClassNumber,
                TeacherName = lesson.TeacherName,
                TeacherSurname = lesson.TeacherSurname
            });

            await context.SaveChangesAsync();

            return Json(NotificationType.Success);

        }
        catch (Exception)
        {
            return Json(NotificationType.Error);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterStudent([FromBody] StudentViewModel student)
    {
        if (!ModelState.IsValid)
        {
            return Json(NotificationType.InvalidModel);
        }
        
        try
        {
            await context.Students.AddAsync(new Student
            {
                StudentNumber = student.StudentNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                ClassNumber = student.ClassNumber,
            });

            await context.SaveChangesAsync();

            return Json(NotificationType.Success);

        }
        catch (Exception)
        {
            return Json(NotificationType.Error);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterExam([FromBody] ExamViewModel exam)
    {
        if (!ModelState.IsValid)
        {
            return Json(NotificationType.InvalidModel);
        }
        
        try
        {
            await context.Exams.AddAsync(new Exam
            {
                LessonId = exam.LessonId,
                StudentId = exam.StudentId,
                ExamDate = exam.ExamDate,
                Grade = exam.Grade
            });

            await context.SaveChangesAsync();

            return Json(NotificationType.Success);

        }
        catch (Exception e)
        {
            return Json(NotificationType.Error);
        }
    }

    public async Task<IActionResult> GetLessons()
    {
        var lessons = await context.Lessons.ToListAsync();
        
        return Json(lessons);
    }
    
    public async Task<IActionResult> GetStudents()
    {
        var students = await context.Students.ToListAsync();
        
        return Json(students);
    }
    
    public async Task<IActionResult> GetClasses()
    {
        var classes = await context.Lessons.Select(x=>x.ClassNumber).Distinct().ToListAsync();
        
        return Json(classes);
    }
}