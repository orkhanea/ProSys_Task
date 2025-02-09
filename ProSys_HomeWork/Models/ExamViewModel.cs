namespace ProSys_HomeWork.Models;

public class ExamViewModel
{
    public int LessonId { get; set; }

    public int StudentId { get; set; }

    public DateOnly ExamDate { get; set; }

    public decimal Grade { get; set; }
}