using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketService.DAL;
using MarketService.Dtos;
using MarketService.Logic;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.Controllers
{
    [Route("markets")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly MarketLogic _marketLogic;
        private readonly IMapper _mapper;

        public MarketController(MarketLogic marketLogic, IMapper mapper)
        {
            _marketLogic = marketLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarketDto>> GetMarkets()
        {
            var marketItems = _marketLogic.GetAllMarkets();

            return Ok(_mapper.Map<IEnumerable<MarketDto>>(marketItems));
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetMarketById(int id)
        {
            var marketItems = _marketLogic.GetMarketById(id);

            return Ok(marketItems);
        }

        [HttpGet]
        [Route("{id}/items")]
        public ActionResult GetItemsByMarket(int id)
        {
            var marketItems = _marketLogic.GetAllItemsByMarketId(id);

            return Ok(marketItems);
        }


        [HttpGet]
        [Route("test")]
        public ActionResult Test()
        {
            return Ok(_marketLogic.Test());
        }
        
    }
}
