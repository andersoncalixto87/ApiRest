using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaPrimeiraApi.ViewModels
{
    public class ProductViewModel
    {    
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100 ,ErrorMessage = "The field {0} must be between {2} e {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "The field {0} must be at least {1}" )]

        public decimal Price { get; set; }
    }
}