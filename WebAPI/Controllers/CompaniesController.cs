using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _companyService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpPost("Add")]
        public IActionResult Add(Company company)
        {
            var result = _companyService.Add(company);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Company company)
        {
            var result = _companyService.Update(company);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Company company)
        {
            var result = _companyService.Delete(company);
            return StatusCode(result.Success ? 200 : 400, result);
        }

    }
}
