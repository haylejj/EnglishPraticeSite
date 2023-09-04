using AutoMapper;
using Core.Dto;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Word,WordDto>().ReverseMap();
            CreateMap<Favorite,FavoriteDto>().ReverseMap();
            CreateMap<Unknows,UnknowsDto>().ReverseMap();
        }
    }
}
