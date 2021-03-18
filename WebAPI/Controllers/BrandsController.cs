using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc; 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result); 
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);             
        }


        [HttpPost("Add")]        
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }

    }
}
