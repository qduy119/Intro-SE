using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [ForeignKey(nameof(Review))]
        public int? ReviewId { get; set; }
        public Review Review { get; set; }
        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public Item Item { get; set; }

    }
}
