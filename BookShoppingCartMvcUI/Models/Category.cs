using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMvcUI.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? CategoryName { get; set; }
        public List<Book>? Books { get; set; }
    }
}
