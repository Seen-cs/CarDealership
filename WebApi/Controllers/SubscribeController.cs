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
using Entities.Concrete;

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

        //giriş yapmış kullanıcının abone olan userları döndürür
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

        //abone olmayı sağlar
        [HttpPost("subscribe")]
        public IActionResult Subscribe(int supUserId)
        {
            var subUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Subscribe subscribe = new Subscribe
            {
                SubUserId = Convert.ToInt16(subUserId),
                SupUserId = supUserId
            };
            
            var result = _subscribeService.Add(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //aboneliğini silmeyi sağlar
        [HttpPost("deletesubscribe")]
        public IActionResult DeleteSubscribe(int supUserId)
        {
            var subUserId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var deletedsub= _subscribeService.GetSubscribeBySupUserIdAndSubUserId(supUserId, subUserId).Data;

            var result = _subscribeService.Delete(deletedsub);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
