using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Data.Exceptiona
{
    public class DuplicateValueException : Exception
    {
        public DuplicateValueException(string fieldName, string value) : base($"Member '{fieldName}' already contains '{value} as a value.")
        {
        }
    }
}