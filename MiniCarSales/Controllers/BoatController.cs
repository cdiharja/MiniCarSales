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
    public class BoatController : Controller
    {
        private readonly IRepositoryService<Boat> boatService;

        public BoatController(IRepositoryService<Boat> boatService)
        {
            this.boatService = boatService;
        }

        [HttpGet]
        public IEnumerable<Boat> Get()
        {
            return this.boatService.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Boat boat)
        {
            this.boatService.Create(boat);
            return Ok(boat);
        }



    }
}
