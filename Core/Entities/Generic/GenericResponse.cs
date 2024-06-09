using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Generic
{
    public class GenericResponse<T>
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public string[]? Errors { get; set; }
        public T? Data { get; set; }
        public static GenericResponse<T> Fail(string errorMessage, string[]? errors = null, int errorCode = 0)
        {
            return new GenericResponse<T> { Succeeded = false, Message = errorMessage, Errors = errors, ErrorCode = errorCode };
        }
        public static GenericResponse<T> Success(T data)
        {
            return new GenericResponse<T> { Succeeded = true, Data = data };
        }
        public int ErrorCode { get; set; }
    }
}
