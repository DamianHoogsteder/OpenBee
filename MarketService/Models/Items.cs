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

        public string Logo { get; set; }
        public Items(int iD, string name, string description, int price)
        {
            ID = iD;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
