using AutoMapper;
using PriceUpdater.Entities;
using PriceUpdater.Models;

namespace PriceUpdater.Profiles
{
    public class KovaniceProfile : Profile
    {
        public KovaniceProfile()
        {
            CreateMap<Zlatne_Kovanice, KovaniceDTO>().ReverseMap();
        }
    }
}
