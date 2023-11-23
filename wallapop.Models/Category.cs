using System.ComponentModel.DataAnnotations;

namespace wallapop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Por favor pon un nombre")]
        public string Name { get; set; }
    }
}
