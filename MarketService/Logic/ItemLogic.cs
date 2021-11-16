using MarketService.DAL.ItemData;
using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Logic
{
    public class ItemLogic
    {
        IItemRepo _itemRepo;

        public ItemLogic(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _itemRepo.GetAllItems();
        }

        public Items GetItemByID(int id)
        {
            return _itemRepo.GetItemById(id);
        }

        public Items AddItem(Items item)
        {
            return _itemRepo.addItem(item);
        }
    }
}
