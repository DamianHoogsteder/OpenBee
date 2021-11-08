using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.DAL.ItemData
{
    public interface IItemRepo
    {
        IEnumerable<Items> GetAllItems();
        Items GetItemById(int id);
    }
}
