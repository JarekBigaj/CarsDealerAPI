
namespace Services.CarService
{
    public interface ICarService
    {
        Task<ServiceResponse<List<GetCarDto>>> GetAllCars();
        Task<ServiceResponse<GetCarDto>> GetCarById(int id);
        Task<ServiceResponse<List<GetCarDto>>> AddCar(AddCarDto newCar);
        Task<ServiceResponse<GetCarDto>> UpdateCar(UpdateCarDto updatedCar);
        Task<ServiceResponse<List<GetCarDto>>> DeleteCar(int id);
    }
}