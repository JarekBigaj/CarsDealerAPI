using AutoMapper;
using CarsDealerApi.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services.CarService
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CarService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCarDto>>> AddCar(AddCarDto newCar)
        {
            var serviceResponse = new ServiceResponse<List<GetCarDto>>();
            var car = _mapper.Map<Car>(newCar);
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                await _context.Cars.Select(car => _mapper.Map<GetCarDto>(car)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarDto>>> DeleteCar(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCarDto>>();
            try
            {
                var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
                if(car is null)
                    throw new Exception($"Charecter with Id '{id}' not found.");


                _context.Cars.Remove(car);

                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Cars.Select(car => _mapper.Map<GetCarDto>(car)).ToListAsync();
            } 
            catch(Exception exception)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = exception.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarDto>>> GetAllCars()
        {
            var serviceResponse = new ServiceResponse<List<GetCarDto>>();
            var cars = await _context.Cars.ToListAsync();
            serviceResponse.Data = cars.Select(car => _mapper.Map<GetCarDto>(car)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> GetCarById(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            var serviceResponse = new ServiceResponse<GetCarDto>();
            serviceResponse.Data = _mapper.Map<GetCarDto>(car);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> UpdateCar(UpdateCarDto updatedCar)
        {
            var serviceResponse = new ServiceResponse<GetCarDto>();
            try
            {
                var car =  await _context.Cars.FirstOrDefaultAsync(car => car.Id == updatedCar.Id);
                if(car is null)
                    throw new Exception($"Charecter with Id '{updatedCar.Id}' not found.");


                car.Make = updatedCar.Make;
                car.Model = updatedCar.Model;
                car.Mileage = updatedCar.Mileage;
                car.Price = updatedCar.Price;
                car.Year = updatedCar.Year;


                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCarDto>(car);
            } 
            catch(Exception exception)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = exception.Message;
            }


            return serviceResponse;
        }
    }
}