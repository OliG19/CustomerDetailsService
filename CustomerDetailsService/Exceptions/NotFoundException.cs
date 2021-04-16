﻿using System;
using Microsoft.AspNetCore.Http;

namespace CustomerDetailsService.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound, message)
        {

        }
    }
}