using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProSys_HomeWork.Data;
using ProSys_HomeWork.Models;

namespace ProSys_HomeWork.Controllers;

public class ResultController(SchoolDbContext context) : Controller
{
    public IActionResult Index()
    {
        var exams = context.Exams.Include(x => x.Lesson).Include(x => x.Student).Select(x => new ResultViewModel
        {
            ExamId = x.Id,
            LessonId = x.LessonId,
            StudentId = x.StudentId,
            StudentNumber = x.Student.StudentNumber,
            ExamDate = x.ExamDate,
            Grade = x.Grade,
            LessonCode = x.Lesson.LessonCode,
            LessonName = x.Lesson.LessonName,
            ClassNumber = x.Student.ClassNumber,
            Teacher = $"{x.Lesson.TeacherName} {x.Lesson.TeacherSurname}",
            Student = $"{x.Student.FirstName} {x.Student.LastName}"
        }).ToList();

        return View(exams);
    }
}