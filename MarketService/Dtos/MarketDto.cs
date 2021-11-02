using MarketService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Dtos
{
    public class MarketDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Logo { get; set; }
        public virtual ICollection<Items> Items {get; set;}
    }
}
