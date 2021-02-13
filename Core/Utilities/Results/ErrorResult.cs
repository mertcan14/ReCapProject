using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string messages):base(false,messages)
        {

        }

        public ErrorResult():base(false)
        {

        }
    }
}
