using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Models
{
    public class Market
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Logo { get; set; }

        public virtual IEnumerable<Items> Items { get; set; }

        public Market(int id, string name, string description, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
        public Market(int id, string name, string description, int price, IEnumerable<Items> items)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Items = items;
        }
    }
}
