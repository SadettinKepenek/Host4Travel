﻿using System.Net;

namespace Host4Travel.Core.BLL.Concrete.Services.AuthService
{
    public class UpdateModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}