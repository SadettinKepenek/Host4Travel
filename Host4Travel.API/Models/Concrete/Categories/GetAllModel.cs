using System.Collections.Generic;
using System.Net;
using Host4Travel.API.Models.Abstract;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.UI;

namespace Host4Travel.API.Models.Concrete.Categories
{
    public class GetAllModel:HttpResponseModel
    {
        public List<CategoryListDto> Categories { get; set; }
 
    }
}