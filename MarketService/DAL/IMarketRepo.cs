using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.DAL
{
    public interface IMarketRepo
    {
        //Saving for the entityframework
        bool SaveChanges();
        IEnumerable<Market> GetAllItemsByMarketId(int id);
        IEnumerable<Market> GetAllMarkets();
        Market GetMarketById(int id);
        IEnumerable<Items> GetAllItems();
        Items GetItemById(int id);

    }
}
