using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.BLL.Concrete;
using Microsoft.Extensions.Logging;
using LogLevel = Host4Travel.Core.BLL.Concrete.LogLevel;

namespace Host4Travel.BLL.Abstract
{
    public interface ILogService
    {
        void Log(string message,LogLevel logLevel);
        List<LogModel> GetAll(Expression<Func<LogModel,bool>> filter=null);
        LogModel Get(Expression<Func<LogModel, bool>> filter = null);
        
    }
}