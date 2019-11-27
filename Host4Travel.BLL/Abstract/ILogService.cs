using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.DTO.LogDtos;
using Host4Travel.Entities.Concrete;
using Microsoft.Extensions.Logging;
using LogLevel = Host4Travel.Core.DTO.LogDtos.LogLevel;

namespace Host4Travel.BLL.Abstract
{
    public interface ILogService
    {
        void Log(Log log);
        List<LogModel> GetAll(Expression<Func<LogModel,bool>> filter=null);
        LogModel Get(Expression<Func<LogModel, bool>> filter = null);
        
    }
}