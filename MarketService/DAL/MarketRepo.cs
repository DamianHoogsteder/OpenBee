using MarketService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.DAL
{
    public class MarketRepo : IMarketRepo
    {
        private readonly MarketDatabaseContext _context;

        public MarketRepo(MarketDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Market> GetAllMarkets()
        {
            return _context.Markets.ToList();
        }

        public IEnumerable<Market> GetAllItemsByMarketId(int id)
        {
            return _context.Markets.Where(i => i.Id == id).Include(m => m.Items);
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Market GetMarketById(int id)
        {
            return _context.Markets.FirstOrDefault(p => p.Id == id);
        }

        public Items GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }
    }
}
