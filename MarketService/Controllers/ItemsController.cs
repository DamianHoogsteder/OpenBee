using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketService.DAL;
using MarketService.Logic;
using MarketService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace MarketService.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ItemLogic _itemLogic;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;


        public ItemsController(ItemLogic itemLogic, IMapper mapper, UserManager<User> userManager)
        {
            _itemLogic = itemLogic;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult GetItemsByMarket()
        {
            var marketItems = _itemLogic.GetAllItems();

            return Ok(marketItems);
        }

        [HttpGet]
        [Route("user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult GetAllItemsByUserID()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

            var Items = _itemLogic.GetAllItemsByUserId(userId);

            return Ok(Items);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetItemsByMarket(int id)
        {
            var item = _itemLogic.GetItemByID(id);

            return Ok(item);
        }

        [HttpGet]
        [Route("buy")]
        public ActionResult GetItemsUpForSale()
        {
            var itemList = new List<Items>();

            var items = _itemLogic.GetAllItems();

            foreach (Items item in items)
            {
                if (item.IsUpForSale == true)
                {
                    itemList.Add(item);
                }
            }

            return Ok(itemList);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Items> AddItem([FromBody] Items item)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

            item.UserId = userId;

            if (item.Name != null)
            {
                _itemLogic.AddItem(item);
                return CreatedAtAction("AddItem", item);

            }
            return StatusCode(404, "Please make sure to give a name");

        }

        [HttpPatch]
        [Route("sell")]
        public ActionResult PutItemUpForSale([FromBody] Items item)
        {
            if (item.IsUpForSale == true)
            {
                _itemLogic.PutUpForSale(item);
                return Ok("Item updatet");
            }
            return StatusCode(405, "Update failed, something went wrong.");
        }
    }
}
