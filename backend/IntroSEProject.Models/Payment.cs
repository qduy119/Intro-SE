using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        [StringLength(50)]
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
