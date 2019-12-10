using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private IDocumentService _documentService;
        private IExceptionHandler _exceptionHandler;

        public DocumentsController(IDocumentService documentService, IExceptionHandler exceptionHandler)
        {
            _documentService = documentService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> AddDocument([FromBody] DocumentAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _documentService.Add(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Document Başarıyla Eklendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
    }
}