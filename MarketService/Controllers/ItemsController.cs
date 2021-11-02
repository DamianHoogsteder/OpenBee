using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IMarketRepo _repository;
        private readonly IMapper _mapper;

        public ItemsController(IMarketRepo reporitory, IMapper mapper)
        {
            _repository = reporitory;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetItemsByMarket()
        {
            var marketItems = _repository.GetAllItems();

            return Ok(marketItems);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetItemsByMarket(int id)
        {
            var item = _repository.GetItemById(id);

            return Ok(item);
        }

    }
}
