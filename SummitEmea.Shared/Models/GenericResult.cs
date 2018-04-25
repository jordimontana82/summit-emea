using System;
using System.Collections.Generic;
using System.Text;

namespace SummitEmea.Shared.Models
{
    public class GenericResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

        public static GenericResult Succeed()
        {
            return new GenericResult() { Succeeded = true };
        } 
    }


    public class GenericResult<T>: GenericResult
    {
        public T Model { get; set; }
    }
}
