using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Models
{
    public class Items
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]

        public int marketId { get; set; }
        public string Logo { get; set; }
        public string UserId { get; set; }
        public bool IsUpForSale { get; set; }

        public Items(int id, string name, string description, int price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Items()
        {

        }
    }
}
