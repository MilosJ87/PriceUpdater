using AutoMapper;
using PriceUpdater.Entities;
using PriceUpdater.Models;

namespace PriceUpdater.Profiles
{
    public class PolugeProfile : Profile
    {
        public PolugeProfile()
        {
            CreateMap<Zlatne_poluge, PolugeDTO>().ReverseMap();
        }
    }
}
