using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.LoggerService;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Concrete
{
    public class DatabaseLogManager:ILogService
    {
        private ILogDal _logDal;

        public DatabaseLogManager(ILogDal logDal)
        {
            _logDal = logDal;
        }
        public void Log(Log log)
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