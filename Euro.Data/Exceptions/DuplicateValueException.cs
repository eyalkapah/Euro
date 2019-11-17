using System;

namespace Euro.Data.Exceptions
{
    public class DuplicateValueException : Exception
    {
        public DuplicateValueException(string fieldName, string value) : base($"Member '{fieldName}' already contains '{value} as a value.")
        {
        }
    }
}