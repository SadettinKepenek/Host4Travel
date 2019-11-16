using System;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.Core.Exceptions
{
    public interface IExceptionHandler
    {
        string HandleControllerException(Exception exception);
        Exception HandleServiceException(Exception e);
    }
}