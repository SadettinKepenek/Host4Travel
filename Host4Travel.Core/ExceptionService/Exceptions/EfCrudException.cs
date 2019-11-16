using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Host4Travel.Core.ExceptionService.Exceptions
{
    [Serializable]
    public class EfCrudException:DbUpdateException
    {
        public EfCrudException(string errorMessage)
            : base($"Veri tabanında hata oluştu \n: {errorMessage}")
        {
            
        }
        public EfCrudException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EfCrudException(string message, IReadOnlyList<IUpdateEntry> entries) : base(message, entries)
        {
        }

        public EfCrudException(string message, Exception innerException, IReadOnlyList<IUpdateEntry> entries) : base(message, innerException, entries)
        {
        }
    }
}