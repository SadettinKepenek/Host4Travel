using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;

namespace Host4Travel.BLL.Concrete
{
    public class DatabaseLogManager:ILogService
    {
        
        public void Log(string message, LogLevel logLevel)
        {
        }

        public List<LogModel> GetAll(Expression<Func<LogModel, bool>> filter = null)
        {
            return null;
        }

        public LogModel Get(Expression<Func<LogModel, bool>> filter = null)
        {
            return null;
        }
    }
}