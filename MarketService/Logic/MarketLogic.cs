using MarketService.DAL;
using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Logic
{
    public class MarketLogic
    {
        IMarketRepo _marketRepo;

        public MarketLogic(IMarketRepo marketRepo)
        {
            _marketRepo = marketRepo;
        }

        public IEnumerable<Market> GetAllMarkets()
        {
            return _marketRepo.GetAllMarkets();
        }

        public IEnumerable<Market> GetAllItemsByMarketId(int id)
        {
            return _marketRepo.GetAllItemsByMarketId(id);
        }

        public Market GetMarketById(int id)
        {
            return _marketRepo.GetMarketById(id);
        }

        public String Test()
        {
            return "hello";
        }
    }
}
