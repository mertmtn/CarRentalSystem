using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetAllCustomerDetail")]
        public IActionResult GetAllCustomerDetail()
        {
            var result = _customerService.GetAllCustomerDetail();
            return StatusCode(result.Success ? 200 : 400, result);

        }

        [HttpGet("GetCustomerDetailById")]
        public IActionResult GetCustomerDetailById(int id)
        {
            var result = _customerService.GetCustomerDetailById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }






    }
}
