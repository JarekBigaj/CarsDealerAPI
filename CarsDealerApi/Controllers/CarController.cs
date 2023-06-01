
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> Get() 
        {
            return Ok(await _carService.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> GetSingle(int id) 
        {
            return Ok(await _carService.GetCarById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> AddCar(AddCarDto newCar)
        {
            return Ok(await _carService.AddCar(newCar));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> UpdateCar(UpdateCarDto updatedCar)
        {
            var response = await _carService.UpdateCar(updatedCar);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> DeleteCar(int id) 
        {
            var response = await _carService.DeleteCar(id);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
    }
}