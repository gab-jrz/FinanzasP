using AutoMapper;
using FinanzasPersonales.Entities;
using FinanzasPersonales.DTOs;

namespace FinanzasPersonales.Mappings
{
    public class GastoProfile : Profile
    {
        public GastoProfile()
        {
            CreateMap<Gasto, GastoDto>().ReverseMap();
        }
    }
}
