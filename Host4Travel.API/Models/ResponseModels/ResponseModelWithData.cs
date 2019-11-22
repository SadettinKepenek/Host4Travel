using System.Net;
using Host4Travel.API.Models.Abstract;

namespace Host4Travel.API.Models
{
    public class ResponseModelWithData<T>:ResponseModelBase
    where T:class,new()
    {
        public T Data { get; set; }
        
    }
    
    
}