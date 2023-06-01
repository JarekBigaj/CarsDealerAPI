using AutoMapper;
using CarsDealerApi.Model;

namespace CarsDealerApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, GetCarDto>();
            CreateMap<AddCarDto, Car>();

        }
    }
}