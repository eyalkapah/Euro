using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Data.Exceptiona
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string value) : base($"Value {value} already exists.")
        {
        }
    }
}