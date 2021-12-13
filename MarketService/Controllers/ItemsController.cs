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

        [HttpPost]
        [Route("sell")]
        public async Task<ActionResult<Items>> AddItem([FromBody] Items item)
        {
            if (item.Name != null)
            {
                _itemLogic.AddItem(item);
                return CreatedAtAction("AddItem", item);

            }
            return StatusCode(404, "Please make sure to give a name");

        }

    }
}
