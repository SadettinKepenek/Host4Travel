using System;
using Host4Travel.Core.ExceptionService.Enum;
using Microsoft.Data.SqlClient;

namespace Host4Travel.Core.ExceptionService.Abstract
{
    public interface IExceptionHandler
    {
        string HandleControllerException(Exception exception);
        Exception HandleServiceException(Exception e);
    }
}