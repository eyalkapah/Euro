using System;

namespace Euro.Data.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string value) : base($"Value {value} already exists.")
        {
        }
    }
}