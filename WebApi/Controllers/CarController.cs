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
        IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;
        public CarController(IUserService userService, ICarService carService, IBrandService brandService, IColorService colorService, IModelService modelService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
            _modelService = modelService;
            _userService = userService;

            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
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

        [HttpPost("getbyuserid")]
        public IActionResult GetByUserId(int carId)
        {
            var result = _carService.GetById(carId);
            var userName = result.Data.UserName;
            var model = result.Data.Model;
            var brand = result.Data.Brand;
            var color = result.Data.Color;
            var userId = _carService.Get(carId).Data.UserId;
            
            CarOwnerUserDto carOwnerUserDto = new CarOwnerUserDto
            {
                UserName=userName,
                Brand=brand,
                Model=model,
                Color=color,
                UserId=userId
            };
            if (result.Success)
            {
                return Ok(carOwnerUserDto);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CarDetailDto carDetailDto)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var brandId = _brandService.Get(carDetailDto.Brand).Data.Id;
                var colorId = _colorService.Get(carDetailDto.Color).Data.Id;
                var modelId = _modelService.Get(carDetailDto.Model).Data.Id;
                Car car = new Car
                {
                    BrandId = brandId,
                    ColorId = colorId,
                    Description = carDetailDto.Description,
                    Km = carDetailDto.Km,
                    ModelId = modelId,
                    Price = carDetailDto.Price,
                    UserId = Convert.ToInt16(userId),
                    Year = carDetailDto.Year
                };
                var result = _carService.Add(car);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception)
            {

                return BadRequest("Hatalı ekleme yapıldı");
            }


        }
    }
}
