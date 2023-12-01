using System.ComponentModel.DataAnnotations;

namespace IntroSEProject.API.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Thumbnail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
    }
}
