using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMvcUI.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }
        [Required]
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail>? OrderDetail { get; set; }
        public List<CartDetail>? CartDetail { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }

    }
}
