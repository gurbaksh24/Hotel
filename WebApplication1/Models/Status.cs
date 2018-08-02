﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Status
    {
        public ApiStatus ApiStatus { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ApiStatus
    {
        Success,
        Warning,
        Failure
    }
}