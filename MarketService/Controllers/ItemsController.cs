﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketService.DAL;
using MarketService.Logic;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ItemLogic _itemLogic;
        private readonly IMapper _mapper;

        public ItemsController(ItemLogic itemLogic, IMapper mapper)
        {
            _itemLogic = itemLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetItemsByMarket()
        {
            var marketItems = _itemLogic.GetAllItems();

            return Ok(marketItems);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetItemsByMarket(int id)
        {
            var item = _itemLogic.GetItemByID(id);

            return Ok(item);
        }

    }
}
