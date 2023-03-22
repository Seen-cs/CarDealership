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
        IColorService _colorService;
        IModelService _modelService;
        private IHttpContextAccessor _httpContextAccessor;
        public CarController(ICarService carService, IBrandService brandService,IColorService colorService,IModelService modelService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
            _modelService = modelService;
   
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
            var modelId = _modelService.GetModelById(carDetailDto.Model);
            var colorId = _colorService.GetColorById(carDetailDto.Color);
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
