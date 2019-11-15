using System;

namespace Host4Travel.Core.Exceptions
{
    [Serializable]
    public class EfCrudException:Exception
    {
        public EfCrudException(string errorMessage)
            : base($"Veri tabanında hata oluştu \n: {errorMessage}")
        {
            
        }
    }
}