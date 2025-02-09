using System.ComponentModel.DataAnnotations;

namespace ProSys_HomeWork.Models;

public class StudentViewModel
{
    [Required(ErrorMessage = "Tələbə nömrəsi məcburi xanadır")]
    [Range(1, 99999, ErrorMessage = "Sinif nömrəsi 1-99999 arasinda olmalıdır")]
    public decimal StudentNumber { get; set; }

    [Required(ErrorMessage = "Tələbənin adı məcburi xanadır")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Tələbənin adı minimum 3 maksimum 30 simvol olmalıdır")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Tələbənin soyadı məcburi xanadır")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Tələbənin soyadı minimum 3 maksimum 30 simvol olmalıdır")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Sinif nömrəsi məcburi xanadır")]
    [Range(1, 12, ErrorMessage = "Sinif nömrəsi 1-12 arasinda olmalıdır")]
    public decimal ClassNumber { get; set; }
}