﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public int StatusCode { get; set; }


        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode };
        }

        public static ResponseDto<T> Success(int statusCode, T data)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static ResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static ResponseDto<T> Fail(int statusCode, string error)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }


    }
}
