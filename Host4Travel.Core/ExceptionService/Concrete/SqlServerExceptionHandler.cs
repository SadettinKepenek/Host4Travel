using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Enum;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.Core.ExceptionService.Concrete
{
    public class SqlServerExceptionHandler : IDatabaseExceptionHandler
    {
        private const int ReferenceConstraint = 547;
        private const int CannotInsertNull = 515;
        private const int CannotInsertDuplicateKeyUniqueIndex = 2601;
        private const int CannotInsertDuplicateKeyUniqueConstraint = 2627;
        private const int ArithmeticOverflow = 8115;
        private const int StringOrBinaryDataWouldBeTruncated = 8152;
        private const int InvalidDatabase = 4060;
        private const int DatabaseLoginFailed = 18452;

        public DatabaseError? GetDatabaseError(SqlException dbException)
        {
            switch (dbException.Number)
            {
                case ReferenceConstraint:
                    return DatabaseError.ReferenceConstraint;
                case CannotInsertNull:
                    return DatabaseError.CannotInsertNull;
                case CannotInsertDuplicateKeyUniqueIndex:
                case CannotInsertDuplicateKeyUniqueConstraint:
                    return DatabaseError.UniqueConstraint;
                case ArithmeticOverflow:
                    return DatabaseError.NumericOverflow;
                case StringOrBinaryDataWouldBeTruncated:
                    return DatabaseError.MaxLength;
                default:
                    return null;
            }
        }

        public DatabaseError? GetDatabaseErrorEf(DbUpdateException dbException)
        {
            if (dbException.InnerException != null)
            {
                var dbExceptionNumber = ((SqlException)dbException.InnerException).Number;
                switch (dbExceptionNumber)
                {
                    case ReferenceConstraint:
                        return DatabaseError.ReferenceConstraint;
                    case CannotInsertNull:
                        return DatabaseError.CannotInsertNull;
                    case CannotInsertDuplicateKeyUniqueIndex:
                    case CannotInsertDuplicateKeyUniqueConstraint:
                        return DatabaseError.UniqueConstraint;
                    case ArithmeticOverflow:
                        return DatabaseError.NumericOverflow;
                    case StringOrBinaryDataWouldBeTruncated:
                        return DatabaseError.MaxLength;
                    default:
                        return null;
                }
                
            }
            else
                return null;
        }
        
    }
}