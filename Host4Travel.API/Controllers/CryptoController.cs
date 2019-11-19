using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : Controller
    {
        private ICrpytoService _crpytoService;

        public CryptoController(ICrpytoService crpytoService)
        {
            _crpytoService = crpytoService;
        }
        [HttpPost("Encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] string password)
        {
            return Ok(_crpytoService.Encrypt(password));
        }

        [HttpPost("Decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] string password)
        {
            return Ok(_crpytoService.Decrypt(password));
        }
    }
}