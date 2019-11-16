using System;
using System.Data.Common;
using System.Reflection;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.Core.ExceptionService.Concrete
{
    public class ExceptionHandler : IExceptionHandler
    {
        public string HandleControllerException(Exception exception)
        {
            string exceptionMessage = "";
            switch (exception)
            {
                case SqlException _:
                    exceptionMessage = "Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                    break;
                case DbUpdateException _:
                    exceptionMessage =
                        "Veritabanında işlem yapılırken hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                    break;
                case DbException _:
                    exceptionMessage = "Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                    break;
                case NullReferenceException _:
                    exceptionMessage = "Gönderileren verinin referansına ulaşılamadı.";
                    break;
                case ArgumentNullException _:
                    exceptionMessage = "Gönderilen veri boş.";
                    break;    
                case ArgumentOutOfRangeException _:
                    exceptionMessage = "Gönderilen veri sınırlar dışında.";
                    break;
                case TimeoutException _:
                    exceptionMessage = "Veritabanında zaman aşımı oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                    break;
                case AmbiguousMatchException _:
                    exceptionMessage = "Gönderilen verilerin alanlarında çakışma oluştu.";
                    break;
                case ValidationFailureException _:
                    exceptionMessage = exception.Message;
                    break;
              
                default:
                    exceptionMessage = "Hata tespit edilemedi";
                    break;
            }
            return exceptionMessage;
        }

        public Exception HandleServiceException(Exception e)
        {
            switch (e)
            {
                case SqlException _:
                    return e;
                case DbUpdateException _:
                    return e;
                case DbException _:
                    return e;
                case ValidationFailureException _:
                    var exceptionMessage = "Veriler eksik detaylar :\n";
                    exceptionMessage += e.Message.Replace("~", "\n");
                    return new ValidationFailureException(exceptionMessage);
                case ArgumentNullException _:
                    return e;
                case NullReferenceException _:
                    return e;
                case ArgumentOutOfRangeException _:
                    return e;
                case AmbiguousMatchException _:
                    return e;
                default:
                    return e;
            }
        }
    }
}