﻿using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}