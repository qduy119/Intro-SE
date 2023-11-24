using System.ComponentModel.DataAnnotations;

namespace IntroSEProject.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Thumbnail { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
