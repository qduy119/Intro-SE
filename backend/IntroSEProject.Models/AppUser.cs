﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroSEProject.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)] 
        public string Email { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        [StringLength(100)]
        [Required]
        public string FullName { get; set; }
        [StringLength(1000)]
        public string Avatar { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
