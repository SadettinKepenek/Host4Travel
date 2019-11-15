using System;
using System.Data.Common;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.Core.Exceptions
{
    public class ExceptionHandler:IExceptionHandler
    {
        public ObjectResult HandleServiceException(Exception exception)
        {
            switch (exception)
            {
                case SqlException _:
                    return new BadRequestObjectResult("Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.");
                case DbUpdateException _:
                    return new BadRequestObjectResult("Veritabanında işlem yapılırken hata oluştu.Lütfen site sahibi ile iletişime geçiniz.");
                case DbException _:
                    return new BadRequestObjectResult("Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.");
                case NullReferenceException _:
                    return new BadRequestObjectResult("Gönderileren verinin referansına ulaşılamadı.");
                case ArgumentNullException _:
                    return new BadRequestObjectResult("Gönderilen veri boş.");
                case ArgumentOutOfRangeException _:
                    return new BadRequestObjectResult("Gönderilen veri sınırlar dışında.");
                case TimeoutException _:
                    return new BadRequestObjectResult("Veritabanında zaman aşımı oluştu.Lütfen site sahibi ile iletişime geçiniz.");
                case AmbiguousMatchException _:
                    return new BadRequestObjectResult("Gönderilen verilerin alanlarında çakışma oluştu.");
                case ValidationFailureException _:
                    return new BadRequestObjectResult($"Veri istenildiği gibi gönderilmedi Detaylar :\n {exception.Message}.");
                case EfCrudException _:
                    return new BadRequestObjectResult("Veritabanında işlem yapılırken hata oluştu.");
                default:
                    return new BadRequestObjectResult("Hata tespit edilemedi");
            }
        }
    }
}