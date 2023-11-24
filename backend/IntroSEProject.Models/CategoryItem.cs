using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class CategoryItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
