using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math4Wpf.Logical
{
    public class FunctionException : Exception
    {
        public FunctionException(string message)
            : base(message) { }
    }
}
