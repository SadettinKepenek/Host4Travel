using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostCheckInService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostCheckInsController : Controller
    {
        private IPostCheckInService _postCheckInService;
        private IExceptionHandler _exceptionHandler;

        public PostCheckInsController(IPostCheckInService postCheckInService, IExceptionHandler exceptionHandler)
        {
            _postCheckInService = postCheckInService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postCheckInService.GetAll();
            if (entities==null)
            {
                return NotFound("Herhangi bir sonuç bulunamadı");
            }
            return Ok(entities);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostCheckInAddDto model)
        {
            try
            {
                _postCheckInService.Add(model);
                return Ok("PostCheckIn Başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostCheckInUpdateDto model)
        {
            try
            {
                _postCheckInService.Update(model);
                return Ok("PostCheckIn Başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] PostCheckInDeleteDto model)
        {
            try
            {
                _postCheckInService.Delete(model);
                return Ok("PostCheckIn Başarıyla silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}