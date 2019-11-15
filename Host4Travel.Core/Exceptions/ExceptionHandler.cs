using System;
using System.Data.Common;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.Core.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        public string HandleServiceException(Exception exception)
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
                    exceptionMessage = "Veri istenildiği gibi gönderilmedi Detaylar :\n" + exception.Message;
                    break;
                case EfCrudException _:
                    exceptionMessage = "Veritabanında işlem yapılırken hata oluştu.";
                    break;
                default:
                    exceptionMessage = "Hata tespit edilemedi";
                    break;
            }
            return exceptionMessage;
        }
    
}
}