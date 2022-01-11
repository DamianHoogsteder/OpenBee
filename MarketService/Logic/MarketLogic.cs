using AutoMapper;
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
        readonly IMarketRepo _marketRepo;
        readonly IMapper _automapper;

        public MarketLogic(IMarketRepo marketRepo, IMapper mapper)
        {
            _marketRepo = marketRepo;
            _automapper = mapper;
        }

        public IEnumerable<Market> GetAllMarkets()
        {
            return _marketRepo.GetAllMarkets();
        }

        public IEnumerable<Market> GetAllItemsAndMarketByMarketId(int id)
        {
            return _marketRepo.GetAllItemsAndMarketByMarketId(id);
        }

        public IEnumerable<Items> GetAllItemsByMarketId(int id)
        {
            return _marketRepo.GetAllItemsByMarketId(id);
        }

        public Market GetMarketById(int id)
        {
            return _marketRepo.GetMarketById(id);
        }
    }
}
