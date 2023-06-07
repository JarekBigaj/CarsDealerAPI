using AutoMapper;
using CarsDealerApi.Dtos.Pagination;
using Data;
using Microsoft.EntityFrameworkCore;


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

        public async Task<ServiceResponse<PaginationDto<List<GetCarDto>>>> GetAllCars(int page)
        {
            var serviceResponse = new ServiceResponse<PaginationDto<List<GetCarDto>>>();
            var pageResults = 7f;
            var cars = await _context.Cars.Where(car => car.Purchase == null).ToListAsync();
            var pageCount = Math.Ceiling(cars.Count()/pageResults);

            var selectCars = cars.Skip((page - 1) * (int)pageResults).Take((int)pageResults).ToList();

            var purchases = await _context.Purchases.ToListAsync();

            var response = new PaginationDto<List<GetCarDto>>{
                    Items = selectCars.Select(car => _mapper.Map<GetCarDto>(car)).ToList(),
                    CurrentPage = page,
                    Pages = (int)pageCount
            };
            serviceResponse.Data =  response;
            
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