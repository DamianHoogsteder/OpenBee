using MarketService.DAL;
using MarketService.Logic;
using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBee_Unittest
{
    class MarketDatabaseContextSTUB : IMarketRepo
    {
        public List<Market> MockMarketList = new List<Market>();
        private List<Items> itemlist = new List<Items>();


        public MarketDatabaseContextSTUB()
        {
            GenerateMockData();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Items> GetAllItemByMarketId(int id)
        {
            List<Market> markets = new List<Market>();
            
            foreach (Market market in MockMarketList)
            {
                if (market.Id == id)
                {
                    return market.Items;
                }
            }
            throw new NotImplementedException();
        }

        public IEnumerable<Market> GetAllMarkets()
        {
            return MockMarketList;
        }

        public Market GetMarketById(int id)
        {
            return MockMarketList.Find(i => i.Id == id);
        }

        private void GenerateMockData()
        {
            itemlist.Add(new Items(1, "item", "itemdsrc", 50));
            MockMarketList.Add(new Market(1, "test", "desrc", 50));
            MockMarketList.Add(new Market(2, "test", "desrc", 50));
            MockMarketList.Add(new Market(3, "test", "desrc", 50));
            MockMarketList.Add(new Market(4, "test", "desrc", 50));
            MockMarketList.Add(new Market(5, "test", "desrc", 50, itemlist));
        }

        IEnumerable<Market> IMarketRepo.GetAllItemsAndMarketByMarketId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Items> GetAllItemsByMarketId(int id)
        {
            List<Market> markets = new List<Market>();

            foreach (Market market in MockMarketList)
            {
                if (market.Id == id)
                {
                    return market.Items;
                }
            }
            throw new NotImplementedException();
        }
    }
}
