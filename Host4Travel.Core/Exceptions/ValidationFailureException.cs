using System;

namespace Host4Travel.Core.Exceptions
{
    [Serializable]
    public class ValidationFailureException:Exception
    {
        public ValidationFailureException(string errorMessage)
            : base($"Veri Doğrulanırken hata oluştu hatalar\n: {errorMessage}")
        {
            
        }
    }
}