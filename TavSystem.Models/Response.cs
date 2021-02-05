using System;
using System.Collections.Generic;
using System.Text;

namespace TavSystem.Models
{
    public class Response
    {
        public Response()
        {
            IsSuccess = true;
            Message = string.Empty;
            Errors = null;
        } 
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Error Errors { get; set; }
    }
    public class Response<T>: Response
    {
        public Response()
        {
        }
        public Response(T data, Paging paging)
        { 
            Data = data;
            Paging = paging;
        }
        public T Data { get; set; } 
        public Paging Paging { get; set; }
    }
    public class Error
    {
        public Error(string code,string description)
        {
            Code = code;
            Description = description;
        }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
