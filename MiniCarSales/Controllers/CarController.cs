using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCarSales.Model;
using MiniCarSales.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("ReactPolicy")]
    public class CarController : Controller
    {
        private readonly IRepositoryService<Car> carService;

        public CarController(IRepositoryService<Car> carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return this.carService.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public  IActionResult Create([FromBody] Car car)
        {   
            car.CreatedDate = DateTime.UtcNow;
            Car result = this.carService.Create(car);
            if (result == null) return BadRequest();
            return Ok(car);
        }



    }
}
