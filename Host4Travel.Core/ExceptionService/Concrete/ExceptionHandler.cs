﻿using System;
using System.Data.Common;
using System.Reflection;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Enum;
using Host4Travel.Core.ExceptionService.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Host4Travel.Core.ExceptionService.Concrete
{
    public class ExceptionHandler : IExceptionHandler
    {
        private IDatabaseExceptionHandler _databaseExceptionHandler;

        public ExceptionHandler(IDatabaseExceptionHandler databaseExceptionHandler)
        {
            _databaseExceptionHandler = databaseExceptionHandler;
        }

        public string HandleControllerException(Exception exception)
        {
            string exceptionMessage = "";

            if (exception is UniqueConstraintException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }

            else if (exception is ReferenceConstraintException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }

            else if (exception is CannotInsertNullException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }

            else if (exception is NumericOverflowException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }
            else if (exception is MaxLengthExceededException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }
            else if (exception is SqlException)
            {
                exceptionMessage = "Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                return exceptionMessage;

            }
            else if (exception is DbUpdateException)
            {
                exceptionMessage =
                    "Veritabanında işlem yapılırken hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                return exceptionMessage;

            }

            else if (exception is DbException _)
            {
                exceptionMessage = "Veritabanında hata oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                return exceptionMessage;

            }
            else if (exception is NullReferenceException _)
            {
                exceptionMessage = "Gönderileren verinin referansına ulaşılamadı.";
                return exceptionMessage;

            }

            else if (exception is ArgumentNullException _)
            {
                exceptionMessage = "Gönderilen veri boş.";
                return exceptionMessage;


            }
            else if (exception is ArgumentOutOfRangeException _)
            {
                exceptionMessage = "Gönderilen veri sınırlar dışında.";
                return exceptionMessage;


            }
            else if (exception is TimeoutException _)
            {
                exceptionMessage = "Veritabanında zaman aşımı oluştu.Lütfen site sahibi ile iletişime geçiniz.";
                return exceptionMessage;


            }
            else if (exception is AmbiguousMatchException _)
            {
                exceptionMessage = "Gönderilen verilerin alanlarında çakışma oluştu.";
                return exceptionMessage;

            }
            else if (exception is ValidationFailureException _)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;

            }
            else if (exception is UnauthorizedAccessException)
            {
                exceptionMessage = exception.Message;
                return exceptionMessage;
            }
            else
            {
                exceptionMessage = exception.Message==string.Empty ? "Hata tespit edilemedi" : exception.Message;
                return exceptionMessage;
            }
        }

        public Exception HandleServiceException(Exception e)
        {
            if (e is SqlException  || e is DbUpdateException)
            {
                var databaseError = _databaseExceptionHandler.GetDatabaseErrorEf(e as DbUpdateException);
                if (databaseError == DatabaseError.UniqueConstraint)
                {
                    return new UniqueConstraintException("Eklenmek istenilen veri zaten mevcut",
                        e.InnerException);
                }

                if (databaseError == DatabaseError.ReferenceConstraint)
                {
                    return new ReferenceConstraintException("Silinmek istenilen veri için kullanılan kayıtlar var",
                        e.InnerException);
                }

                if (databaseError == DatabaseError.CannotInsertNull)
                {
                    return new CannotInsertNullException("NULL Değer eklenilemez", e.InnerException);
                }

                if (databaseError == DatabaseError.NumericOverflow)
                {
                    return new NumericOverflowException("Eklenilmek istenilen veri,bulunduğu alanı taşırıyor",
                        e.InnerException);
                }

                if (databaseError == DatabaseError.MaxLength)
                {
                    return new MaxLengthExceededException("Veri istenilen boyutun üstünde", e.InnerException);
                }

                return e;
            }

            if (e is ValidationFailureException)
            {
                var exceptionMessage = "Veriler eksik gönderildi.Detaylar :\n";
                exceptionMessage += e.Message.Replace("~", "\n");
                return new ValidationFailureException(exceptionMessage);
            }

            if (e is ArgumentNullException exArgumentNull)
            {
                return exArgumentNull;
            }

            if (e is NullReferenceException exNull)
            {
                return exNull;
            }

            if (e is ArgumentOutOfRangeException exArgumentOutOfRange)
            {
                return exArgumentOutOfRange;
            }

            if (e is AmbiguousMatchException exAmbiguousMatch)
            {
                return exAmbiguousMatch;
            }

            if (e is UnauthorizedAccessException exUnauthorizedAccess)
            {
                return exUnauthorizedAccess;
            }

            return e;
        }
    }
}