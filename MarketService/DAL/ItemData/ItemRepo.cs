using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.DAL.ItemData
{
    public class ItemRepo : IItemRepo
    {
        private readonly MarketDatabaseContext _context;

        public ItemRepo(MarketDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<Items> GetAllItemsByUserID(string userID)
        {
            return _context.Items.Where(i => i.UserId == userID).ToList();
        }

        public Items GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.ID == id);
        }

        public Items addItem(Items item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item; 
        }

    }
}
