using System.Collections.Generic;
using System.Net;
using Host4Travel.API.Models.Abstract;
using Host4Travel.UI;

namespace Host4Travel.API.Models.Concrete.Categories
{
    public class GetAllModel:HttpResponseModel
    {
        public List<Category> Categories { get; set; }
 
    }
}