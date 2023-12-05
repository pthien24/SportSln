using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Models
{
    public class Product
    {
        public long? ProductId {  get; set; }
        [Required(ErrorMessage = "please enter a product name ")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "please enter a product Description ")]
        public string Description { get; set; } = String.Empty;

        [Required]
        [Range(0.01 , double.MaxValue , ErrorMessage = "Please enter positive price ")]
        [Column (TypeName = "decimal(8,2)" )]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="please specify a category")]
        public string Category { get; set; } = String.Empty;
    }
}
