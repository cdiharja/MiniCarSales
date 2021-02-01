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
    public class HomeController : Controller
    {
        private readonly HelperService helperService;
        public HomeController(HelperService helperService)
        {
            this.helperService = helperService;

        }

        public HomeData Index()
        {
            return helperService.GenerateHomeData<VehicleType>(VehicleType.Car);
        }
    }
}
