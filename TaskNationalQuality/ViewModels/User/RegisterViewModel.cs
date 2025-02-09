using System.ComponentModel.DataAnnotations;

namespace TaskNationalQuality.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? Username { get; set; }

        [Required]
        [StringLength(100)]
        public string? CustomerName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d).{6,}$", ErrorMessage = "Password must contain at least one number and be at least 6 characters long.")]
        public string? Password { get; set; }

    }
}
