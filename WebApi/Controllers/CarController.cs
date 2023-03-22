using Business.Abstract;
using Core.Utilities.IoC;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private IHttpContextAccessor _httpContextAccessor;
        public CarController(ICarService carService, IBrandService brandService,IColorService colorService,IModelService modelService,IUserService userService)
        {
            _carService = carService;
            _brandService = brandService;
            color = colorService;
            model = modelService;
            user = userService;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
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
        public IActionResult Add(CarDetailDto carDetailDto)
        {
            var brand = _brandService.GetBrandById(carDetailDto.Brand);
            var modelId = model.GetModelById(carDetailDto.Model);
            var colorId = color.GetColorById(carDetailDto.Color);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Car car = new Car
            {
                BrandId=brand,
                ColorId=colorId,
                Description=carDetailDto.Description,
                Km=carDetailDto.Km,
                ModelId=modelId,
                Price=carDetailDto.Price,
                UserId=Convert.ToInt16(userId),
                Year=carDetailDto.Year
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
