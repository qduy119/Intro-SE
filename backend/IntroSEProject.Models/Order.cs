using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int Total { get; set; }
        public int SeatNumber { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
