using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostApplicationService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostApplicationsController : Controller
    {
        private IPostApplicationService _postApplicationService;
        private IExceptionHandler _exceptionHandler;

        public PostApplicationsController(IPostApplicationService postApplicationService, IExceptionHandler exceptionHandler)
        {
            _postApplicationService = postApplicationService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postApplicationService.GetAllApplications();
            if (entities==null)
            {
                return NotFound("Herhangi bir kayıt bulunamadı");
            }
            return Ok(entities);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostApplicationAddDto model)
        {
            try
            {
                _postApplicationService.AddApplication(model);
                return Ok("Başvuru başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostApplicationUpdateDto model)
        {
            try
            {
                _postApplicationService.UpdateApplication(model);
                return Ok("Başvuru başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PostApplicationDeleteDto model)
        {
            try
            {
                _postApplicationService.DeleteApplication(model);
                return Ok("Başvuru başarıyla silindi.");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}