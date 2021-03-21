using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("RentACar")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("GetRentalsByCustomerId")]
        public IActionResult GetRentalsByCustomerId(int customerId)
        {
            var result = _rentalService.GetRentalsByCustomerId(customerId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetRentalById")]
        public IActionResult GetRentalById(int rentalId)
        {
            var result = _rentalService.GetRentalById(rentalId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetRentalDetailById")]
        public IActionResult GetRentalDetailById(int rentalId)
        {
            var result = _rentalService.GetRentalDetailById(rentalId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("GetAllRentalDetail")]
        public IActionResult GetAllRentalDetail()
        {
            var result = _rentalService.GetAllRentalDetail();
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
