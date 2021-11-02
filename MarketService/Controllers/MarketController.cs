using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketService.DAL;
using MarketService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketRepo _repository;
        private readonly IMapper _mapper;

        public MarketController(IMarketRepo reporitory, IMapper mapper)
        {
            _repository = reporitory;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarketDto>> GetMarkets()
        {
            Console.WriteLine("Fetching Marketplaces");

            var marketItems = _repository.GetAllMarkets();

            return Ok(_mapper.Map<IEnumerable<MarketDto>>(marketItems));
        }

        [HttpGet]
        [Route("{id}/items")]
        public ActionResult GetItemsByMarket(int id)
        {
            var marketItems = _repository.GetAllItemsByMarketId(id);

            return Ok(marketItems);
        }


    }
}
