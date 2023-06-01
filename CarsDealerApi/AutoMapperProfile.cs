using AutoMapper;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Dtos.Purchase;
using CarsDealerApi.Dtos.TestDrive;

namespace CarsDealerApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, GetCarDto>();
            CreateMap<AddCarDto, Car>();
            CreateMap<Offer, GetOfferDto>();
            CreateMap<AddOfferDto,Offer>();
            CreateMap<AddPurchaseDto, Purchase>();
            CreateMap<Purchase, GetPurchaseDto>();
            CreateMap<TestDrive, GetTestDriveDto>();
            CreateMap<AddTestDriveDto, TestDrive>();
            
        }
    }
}