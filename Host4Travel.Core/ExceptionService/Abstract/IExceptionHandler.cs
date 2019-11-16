using System;

namespace Host4Travel.Core.ExceptionService.Abstract
{
    public interface IExceptionHandler
    {
        string HandleControllerException(Exception exception);
        Exception HandleServiceException(Exception e);
    }
}