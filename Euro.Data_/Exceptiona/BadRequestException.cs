using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Data.Exceptiona
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {
        }
    }
}