﻿using Microsoft.AspNetCore.Http;

namespace Host4Travel.API.Extensions
{
    public static class JwtExtension
    {
        public static void AddApplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-Control-Allow-Origin","*");
            response.Headers.Add("Access-Control-Expose-Header","Application-Error");
            
        }
    }
}