using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Host4Travel.Core.ExceptionService.Exceptions
{
    [Serializable]
    public class UniqueConstraintException:DbUpdateException
    {
        public UniqueConstraintException(string message) : base(message)
        {
        }

        public UniqueConstraintException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UniqueConstraintException(string message, IReadOnlyList<IUpdateEntry> entries) : base(message, entries)
        {
        }

        public UniqueConstraintException(string message, Exception innerException, IReadOnlyList<IUpdateEntry> entries) : base(message, innerException, entries)
        {
        }
    }
}