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
        IEnumerable<Items> GetAllItemsByUserID(string userID);
        Items GetItemById(int id);
        Items addItem(Items item);
        void PutUpForSale(Items item);

    }
}
