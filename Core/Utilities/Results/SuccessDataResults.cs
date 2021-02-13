using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResults<T> : DataResult<T>
    {
        public SuccessDataResults(T data, string messages):base(data, true, messages)
        {

        }

        public SuccessDataResults(T data):base(data, true)
        {

        }

        public SuccessDataResults(string messages) : base(default, true, messages) 
        {

        }

        public SuccessDataResults():base(default, true)
        {

        }
    }
}
