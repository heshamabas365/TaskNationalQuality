using System.ComponentModel.DataAnnotations;

namespace TaskNationalQuality.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal? Price { get; set; }

    }
}


