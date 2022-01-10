using AutoMapper;
using MarketService.DAL;
using MarketService.Dtos;
using MarketService.Logic;
using MarketService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OpenBee_Unittest
{
    [TestClass]
    public class MarketServiceTests
    {
        private readonly MarketLogic _marketLogic;
        private readonly MarketDatabaseContextSTUB stub;

        public MarketServiceTests()
        {
            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<Market, MarketDto>().ReverseMap();
            });
            
            IMarketRepo _IMarketRepo = new MarketDatabaseContextSTUB();
            IMapper _mapper = new Mapper(config);
            _marketLogic = new MarketLogic(_IMarketRepo, _mapper);
        }

        [TestMethod]
        public void GetAllMarkets_ComparesToSameList_AreEqual()
        {
            //Arrange
            IEnumerable<Market> markets = new List<Market>();

            //Act
            markets = _marketLogic.GetAllMarkets();

            //Assert
            Assert.AreEqual(markets, _marketLogic.GetAllMarkets());
        }

        [TestMethod]
        public void GetAllMarkets_ComparesToDifferentList_AreNotEqual()
        {
            //Arrange
            List<Market> markets = new List<Market>();
            IEnumerable<Market> compareMarkets = new List<Market>();

            //Act
            markets.Add(new Market(1, "aa", "desrc", 50));
            markets.Add(new Market(2, "tbbest", "desrc", 50));
            markets.Add(new Market(3, "tebbst", "desrc", 50));
            markets.Add(new Market(4, "tebbst", "desrc", 50));

            compareMarkets = _marketLogic.GetAllMarkets();

            //Assert
            Assert.AreNotEqual(markets, compareMarkets);
        }

        [TestMethod]
        public void GetMarketById_IdExists_True()
        {
            //Arrange
            int id = 1;

            //Act
            Market market = _marketLogic.GetMarketById(id);

            //Assert
            Assert.IsTrue(market.Id == id);
        }

        [TestMethod]
        public void GetMarketById_IdDoesNotExist_IsNull()
        {
            //Arrange
            int id = 999;

            //Act
            Market market = _marketLogic.GetMarketById(id);

            //Assert
            Assert.IsNull(market);
        }

        [TestMethod]
        public void GetAllItemsByMarketId_IdContainsMarketWithItems_IsNotNull()
        {
            //Arrange
            int id = 5;
            IEnumerable<Items> items = new List<Items>();

            //Act
            items = _marketLogic.GetAllItemsByMarketId(id);

            //Assert
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void GetAllItemsByMarketId_IdDoesNotContainItems_IsNull()
        {
            //Arrange
            int id = 3;
            IEnumerable<Items> items = new List<Items>();

            //Act
            items = _marketLogic.GetAllItemsByMarketId(id);

            //Assert
            Assert.IsNull(items);
        }
    }
}
