﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
