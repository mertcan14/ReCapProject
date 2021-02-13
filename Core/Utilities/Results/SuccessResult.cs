using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult():base(true)
        {

        }

        public SuccessResult(string messages):base(true, messages)
        {

        }
    }
}
