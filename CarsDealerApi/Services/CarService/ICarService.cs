
using CarsDealerApi.Dtos.Pagination;

namespace Services.CarService
{
    public interface ICarService
    {
        Task<ServiceResponse<PaginationDto<List<GetCarDto>>>> GetAllCars(int page);
        Task<ServiceResponse<GetCarDto>> GetCarById(int id);
        Task<ServiceResponse<List<GetCarDto>>> AddCar(AddCarDto newCar);
        Task<ServiceResponse<GetCarDto>> UpdateCar(UpdateCarDto updatedCar);
        Task<ServiceResponse<List<GetCarDto>>> DeleteCar(int id);
    }
}