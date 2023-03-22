using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        ISubscribeService _subscribeService;
        private IHttpContextAccessor _httpContextAccessor;
        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _subscribeService.GetClaims();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getallsubuser")]
        public IActionResult GetAllSubUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _subscribeService.GetAllSubUserBySupUserId(Convert.ToInt16(userId));
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        //giriş yapmış kullanıcının abone olan userları döndürür
    }
}
