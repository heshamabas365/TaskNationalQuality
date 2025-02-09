using System.ComponentModel.DataAnnotations;

namespace TaskNationalQuality.ViewModels.User
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
