﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Host4Travel.Core.ExceptionService.Exceptions
{
    [Serializable]
    public class MaxLengthExceededException:DbUpdateException
    {
        public MaxLengthExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public MaxLengthExceededException(string message, IReadOnlyList<IUpdateEntry> entries) : base(message, entries)
        {
        }

        public MaxLengthExceededException(string message, Exception innerException, IReadOnlyList<IUpdateEntry> entries) : base(message, innerException, entries)
        {
        }
    }
}