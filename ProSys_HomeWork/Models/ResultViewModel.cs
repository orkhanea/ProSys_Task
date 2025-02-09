namespace ProSys_HomeWork.Models;

public class ResultViewModel
{
    public int ExamId { get; set; }

    public int LessonId { get; set; }

    public int StudentId { get; set; }

    public DateOnly ExamDate { get; set; }

    public decimal Grade { get; set; }
    
    public string LessonCode { get; set; } = null!;

    public string LessonName { get; set; } = null!;

    public decimal ClassNumber { get; set; }

    public string Teacher { get; set; } = null!;
    
    public decimal StudentNumber { get; set; }

    public string Student { get; set; } = null!;
    
}