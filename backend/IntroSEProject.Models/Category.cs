using System.ComponentModel.DataAnnotations;

namespace IntroSEProject.Models
{
    public class Category
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
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
    }
}
