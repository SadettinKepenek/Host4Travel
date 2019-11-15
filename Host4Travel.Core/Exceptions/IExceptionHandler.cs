using System;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.Core.Exceptions
{
    public interface IExceptionHandler
    {
        ObjectResult HandleServiceException(Exception exception);
    }
}