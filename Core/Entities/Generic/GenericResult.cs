using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Generic
{
    public class GenericResult<T>
    {
        public bool IsValid { get; set; }
        public T Model { get; set; }

        public static GenericResult<T> Fail()
        {
            return new GenericResult<T> { IsValid = false };
        }
        public static GenericResult<T> Success(T data)
        {
            return new GenericResult<T> { IsValid = true, Model = data };
        }
    }
}

