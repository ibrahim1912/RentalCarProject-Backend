using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {  
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            //Thread.Sleep(2000);
            var result = _carService.GetCarsWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {

            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            //Thread.Sleep(2000);
            var result = _carService.GetByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorId)
        {
            //Thread.Sleep(2000);
            var result = _carService.GetByColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")] 
        public IActionResult GetById(int carId)
        {
            //Thread.Sleep(2000);
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailbyid")] 
        public IActionResult GetCarDetail(int carId)
        {
            //Thread.Sleep(2000);
            var result = _carService.GetCarDetails(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandandcolor")]
        public IActionResult GetCarsByBrandAndColor(int brandId, int colorId)
        {
            var result = _carService.GetCarsByBrandAndColor(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
