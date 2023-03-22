using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        IBrandService _brandService;
        IColorService color;
        IModelService model;
        IUserService user;
        public CarController(ICarService carService, IBrandService brandService,IColorService colorService,IModelService modelService,IUserService userService)
        {
            _carService = carService;
            _brandService = brandService;
            color = colorService;
            model = modelService;
            user = userService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(CarDetailDto carDetailDto)
        {
            var brand = _brandService.GetBrandById(carDetailDto.brand);
            var modelId = model.GetModelById(carDetailDto.model);
            var colorId = color.GetColorById(carDetailDto.color);
            var userId = user.GetUserById(carDetailDto.userName);
            Car car = new Car
            {
                BrandId=brand,
                ColorId=colorId,
                Description=carDetailDto.description,
                Km=carDetailDto.km,
                ModelId=modelId,
                Price=carDetailDto.price,
                UserId=userId,
                Year=carDetailDto.year
            };
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
