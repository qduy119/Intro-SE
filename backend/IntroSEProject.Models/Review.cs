using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [ForeignKey(nameof(OrderItem))]
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
