using AutoMapper;
using MarketService.Dtos;
using MarketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.Profiles
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            //source --> target
            CreateMap<Market, MarketDto>();
        }
    }
}
