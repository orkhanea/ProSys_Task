using System.ComponentModel.DataAnnotations;

namespace ProSys_HomeWork.Models;

public class LessonViewModel
{
    [Required(ErrorMessage = "Dərs kodu məcburi xanadır")]
    [MaxLength(3, ErrorMessage = "Maksimum 3 simvol ola bilər")]
    public string LessonCode { get; set; } = null!;

    [Required(ErrorMessage = "Dərs adı məcburi xanadır")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Dərs adı minimum 3 maksimum 30 simvol olmalıdır")]
    public string LessonName { get; set; } = null!;

    [Required(ErrorMessage = "Sinif nömrəsi məcburi xanadır")]
    [Range(1, 12, ErrorMessage = "Sinif nömrəsi 1-12 arasinda olmalıdır")]
    public decimal ClassNumber { get; set; }

    [Required(ErrorMessage = "Müəllimin adı məcburi xanadır")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Müəllimin adı minimum 3 maksimum 30 simvol olmalıdır")]
    public string TeacherName { get; set; } = null!;

    [Required(ErrorMessage = "Müəllimin soyadı mütləqdir!")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Müəllimin soyadı minimum 3 maksimum 30 simvol olmalıdır")]
    public string TeacherSurname { get; set; } = null!;
}