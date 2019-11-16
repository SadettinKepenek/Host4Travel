using Host4Travel.Core.ExceptionService.Enum;
using Microsoft.Data.SqlClient;

namespace Host4Travel.Core.ExceptionService.Abstract
{
    public interface IDatabaseExceptionHandler
    {
        DatabaseError? GetDatabaseError(SqlException dbException);
    }
}